using EYE.Enumeradores;
using EYE.Servicio.Data;
using Facturacion.CFDI4._0;
using Facturacion.CFDI40;
using Facturacion.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmpaqueCeresWeb.Web.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly EyeContext _context;
        public FacturacionController(EyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public FileResult DownloadPDF([FromQuery] int id)
        {
            var embarque = _context.Embarque.Where(x => x.IdEmbarque == id).FirstOrDefault();

            var Serie = (embarque.TipoEmbarque == TipoEmbarqueEnum.Exportacion ? "EXP" : "NAC") + embarque.Temporada;
            var Folio = embarque.Manifiesto.ToString();

            string rutaPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot\\XMLs\\{Serie + "-" + Folio}.pdf");

            byte[] fileBytes = System.IO.File.ReadAllBytes(rutaPDF);
            return File(fileBytes, "application/pdf", $"{Serie + "-" + Folio}.pdf");
        }
        public FileResult DownloadXML([FromQuery] int id)
        {
            try
            {
                var embarque = _context.Embarque.Where(x => x.IdEmbarque == id).FirstOrDefault();

                var Serie = (embarque.TipoEmbarque == TipoEmbarqueEnum.Exportacion ? "EXP" : "NAC") + embarque.Temporada;
                var Folio = embarque.Manifiesto.ToString();

                string rutaXML = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot\\XMLs\\{Serie + "-" + Folio}.xml");

                byte[] fileBytes = System.IO.File.ReadAllBytes(rutaXML);
                return File(fileBytes, "application/xml", $"{Serie + "-" + Folio}.xml");
            }
            catch (Exception)
            {

                return null;
            }

        }
        [HttpGet]
        public async Task<JsonResult> Facturar([FromQuery] int id)
        {

            try
            {
                var varlorTipoCambio = await _context.TiposCambios.Where(x => x.Fecha.Date == DateTime.Now.Date).FirstOrDefaultAsync();

                if (varlorTipoCambio != null)
                {

                    var cfdi = new Comprobante();
                    var comercioExterior = new ComercioExterior();

                    var empresa = await _context.Empresa.FirstOrDefaultAsync();
                    var embarque = await _context.Embarque.Where(x => x.IdEmbarque == id).FirstOrDefaultAsync();
                    var destino = await _context.Destinos.Where(x => x.IdDestino == embarque.IdDestino).FirstOrDefaultAsync();
                    var cliente = await _context.Clientes.Where(x => x.IdCliente == embarque.IdCliente).FirstOrDefaultAsync();
                    var detalle = await _context.EmbarqueDetalleFacturacionView.Where(x => x.IdEmbarque == id).ToListAsync();


                    decimal total = (decimal)detalle.Sum(x => x.Importe);

                    string rutaCer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"wwwroot\certificados\FYF2010071IA.cer");
                    string pathKey = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"wwwroot\certificados\FYF2010071IA.key");
                    string clavePrivada = "FYF2010071IA";


                    var selloDigital = new SelloDigital(rutaCer, pathKey, clavePrivada);



                    cfdi.Serie = (embarque.TipoEmbarque == TipoEmbarqueEnum.Exportacion ? "EXP" : "NAC") + embarque.Temporada;
                    cfdi.Folio = embarque.Manifiesto.ToString();
                    cfdi.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                    cfdi.FormaPago = "03";
                    cfdi.MetodoPago = "PUE";
                    cfdi.NoCertificado = selloDigital.NumeroCertificado();
                    cfdi.Certificado = selloDigital.Certificado();
                    cfdi.SubTotal = (decimal)Math.Round(total, 2);
                    cfdi.Moneda = "USD";
                    cfdi.TipoCambio = (decimal)varlorTipoCambio.Valor;
                    cfdi.Total = (decimal)Math.Round(total, 2);
                    cfdi.TipoDeComprobante = "I";

                    cfdi.LugarExpedicion = empresa.CodigoPostal;


                    cfdi.Exportacion = "02";

                    cfdi.Emisor = new ComprobanteEmisor()
                    {


                        Rfc = empresa.RFC,
                        Nombre = empresa.Nombre,
                        RegimenFiscal = empresa.CveRegimenFiscal
                    };

                    cfdi.Receptor = new ComprobanteReceptor()
                    {
                        Rfc = cliente.RFC,
                        Nombre = cliente.Nombre,
                        ResidenciaFiscal = cliente.CveRecidenciaFiscal,
                        RegimenFiscalReceptor = cliente.CveRegimenFiscal,
                        UsoCFDI = "S01",
                        NumRegIdTrib = cliente.NumRegIdTrib,
                        DomicilioFiscalReceptor = empresa.CodigoPostal
                    };

                    cfdi.Conceptos = new ComprobanteConcepto[detalle.Count];
                    var i = 0;
                    foreach (var item in detalle)
                    {
                        cfdi.Conceptos[i] = new ComprobanteConcepto() { ObjetoImp = "01", ClaveProdServ = item.CveProductoServicio, NoIdentificacion = item.CodigoProducto, Cantidad = item.Cantidad, ClaveUnidad = item.CveUnidadMedida, Descripcion = item.Producto, ValorUnitario = (decimal)item.Precio, Importe = (decimal)item.Importe };
                        i++;
                    }

                    comercioExterior.ClaveDePedimento = "A1";
                    comercioExterior.CertificadoOrigen = 0;
                    comercioExterior.Incoterm = "FCA";;
                    comercioExterior.TipoCambioUSD = (decimal)varlorTipoCambio.Valor;
                    comercioExterior.TotalUSD = Math.Round(total * 1.00M, 2);

                    comercioExterior.Emisor = new ComercioExteriorEmisor()
                    {
                        Domicilio = new ComercioExteriorEmisorDomicilio { Calle = empresa.Calle, Municipio = "018", Estado = empresa.CveEstado, Pais = empresa.CvePais, CodigoPostal = empresa.CodigoPostal },
                    };
                    comercioExterior.Receptor = new ComercioExteriorReceptor()
                    {
                        Domicilio = new ComercioExteriorReceptorDomicilio { Calle = destino.Calle, NumeroExterior = destino.NumeroExterior, Localidad = destino.Localidad, Municipio = destino.Municipio, Estado = destino.CveEstado, Pais = destino.CvePais, CodigoPostal = destino.CodigoPostal },
                        NumRegIdTrib = cliente.NumRegIdTrib
                    };


                    comercioExterior.Mercancias = new ComercioExteriorMercancia[detalle.Count];
                    i = 0;
                    foreach (var item in detalle)
                    {
                        comercioExterior.Mercancias[i] = new ComercioExteriorMercancia() { NoIdentificacion = item.CodigoProducto, FraccionArancelaria = item.CveFraccionArancelaria, CantidadAduana = (decimal)item.Kilogramos, UnidadAduana = "01", ValorUnitarioAduana = Math.Round(((decimal)item.Importe / (decimal)item.Kilogramos) * 1.00M, 2), ValorDolares = (decimal)item.Importe };
                        i++;
                    }

                    cfdi.AgregarComplemento(comercioExterior);

                    cfdi.Sello = selloDigital.Sellar(cfdi.CadenaOriginal());

                    var timbrador = new Facturar("816db274889c44bb8ce0132e83a927cb");

                    Respuesta res = await timbrador.Timbrar(cfdi.XMLString());


                    if (res.EsCorrecto)
                    {


                        try
                        {

                            string rutaXML = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot\\XMLs\\{cfdi.Serie + "-" + cfdi.Folio}.xml");
                            string rutaPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot\\XMLs\\{cfdi.Serie + "-" + cfdi.Folio}.pdf");

                            timbrador.GenerarArchivoXML(res.Data, rutaXML);
                            timbrador.GenerarPDF(res.Data, rutaPDF);

                            var obj = timbrador.LeerXML(rutaXML);

                            embarque.EstaTimbrado = true;
                            embarque.FolioFiscalDigital = obj.TimbreFiscalDigital.UUID;

                            _context.Embarque.Update(embarque);
                            await _context.SaveChangesAsync();


                            return new JsonResult(new { ExisteError = false, mensaje = "Se timbro correctamente" });
                        }
                        catch (Exception ex)
                        {
                            return new JsonResult(new { ExisteError = true, mensaje = ex.Message });
                        }
                    }
                    else
                    {
                        return new JsonResult(new { ExisteError = true, mensaje = "No se a timbrado -> " + res.Mensaje });
                    }
                }
                else
                {
                    return new JsonResult(new { ExisteError = true, mensaje = "No se a configurado el tipo de cambio para el dia de hoy" });
                }


            }
            catch (Exception ex)
            {

                return new JsonResult(new { ExisteError = true, mensaje = ex.Message });
            }
        }

        //public async Task<JsonResult> FacturarDev([FromQuery] int id)
        //{

        //    try
        //    {


        //        var varlorTipoCambio = await _context.TiposCambios.Where(x => x.Fecha.Date == DateTime.Now.Date).FirstOrDefaultAsync();


        //        if (varlorTipoCambio != null)
        //        {

        //            var cfdi = new Comprobante();
        //            var comercioExterior = new ComercioExterior();

        //            var empresa = await _context.Empresa.FirstOrDefaultAsync();
        //            var embarque = await _context.Embarque.Where(x => x.IdEmbarque == id).FirstOrDefaultAsync();
        //            var destino = await _context.Destinos.Where(x => x.IdDestino == embarque.IdDestino).FirstOrDefaultAsync();
        //            var cliente = await _context.Clientes.Where(x => x.IdCliente == embarque.IdCliente).FirstOrDefaultAsync();
        //            //var detalle = await _context.EmbarqueDetalleFacturacionView.Where(x => x.IdEmbarque == id).ToListAsync();


        //            decimal total = (decimal)detalle.Sum(x => x.Importe);

        //            string rutaCer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"wwwroot\certificados\EKU9003173C9.cer");
        //            string pathKey = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"wwwroot\certificados\EKU9003173C9.key");
        //            string clavePrivada = "12345678a";


        //            var selloDigital = new SelloDigital(rutaCer, pathKey, clavePrivada);



        //            cfdi.Serie = (embarque.TipoEmbarque == TipoEmbarqueEnum.Exportacion ? "EXP" : "NAC") + embarque.Temporada;
        //            cfdi.Folio = embarque.Manifiesto.ToString();
        //            cfdi.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        //            cfdi.FormaPago = "03";
        //            cfdi.MetodoPago = "PUE";
        //            cfdi.NoCertificado = selloDigital.NumeroCertificado();
        //            cfdi.Certificado = selloDigital.Certificado();
        //            cfdi.SubTotal = (decimal)Math.Round(total, 2);
        //            cfdi.Moneda = "USD";
        //            cfdi.TipoCambio = (decimal)varlorTipoCambio.Valor;
        //            cfdi.Total = (decimal)Math.Round(total, 2);
        //            cfdi.TipoDeComprobante = "I";

        //            cfdi.LugarExpedicion = "42501";


        //            cfdi.Exportacion = "02";

        //            cfdi.Emisor = new ComprobanteEmisor()
        //            {


        //                Rfc = "EKU9003173C9",
        //                Nombre = "ESCUELA KEMPER URGATE",
        //                RegimenFiscal = empresa.CveRegimenFiscal//"622",
        //            };

        //            cfdi.Receptor = new ComprobanteReceptor()
        //            {
        //                Rfc = cliente.RFC,
        //                Nombre = cliente.Nombre,
        //                ResidenciaFiscal = cliente.CveRecidenciaFiscal,
        //                RegimenFiscalReceptor = cliente.CveRegimenFiscal,
        //                UsoCFDI = "S01",
        //                NumRegIdTrib = cliente.NumRegIdTrib,
        //                DomicilioFiscalReceptor = "42501"
        //            };


        //            cfdi.Conceptos = new ComprobanteConcepto[detalle.Count];
        //            var i = 0;
        //            foreach (var item in detalle)
        //            {
        //                cfdi.Conceptos[i] = new ComprobanteConcepto() { ObjetoImp = "01", ClaveProdServ = item.CveProductoServicio, NoIdentificacion = item.CodigoProducto, Cantidad = item.Cantidad, ClaveUnidad = item.CveUnidadMedida, Descripcion = item.Producto, ValorUnitario = (decimal)item.Precio, Importe = (decimal)item.Importe };
        //                i++;
        //            }


        //            comercioExterior.TipoOperacion = "2";
        //            comercioExterior.ClaveDePedimento = "A1";
        //            comercioExterior.CertificadoOrigen = 0;
        //            comercioExterior.Incoterm = "FCA";
        //            comercioExterior.Subdivision = 0;
        //            comercioExterior.TipoCambioUSD = (decimal)varlorTipoCambio.Valor;
        //            comercioExterior.TotalUSD = Math.Round(total * 1.00M, 2);

        //            comercioExterior.Emisor = new ComercioExteriorEmisor()
        //            {
        //                Domicilio = new ComercioExteriorEmisorDomicilio { Calle = empresa.Calle, Municipio = "018", Estado = "HID", Pais = empresa.CvePais, CodigoPostal = "42501" },
        //            };
        //            comercioExterior.Receptor = new ComercioExteriorReceptor()
        //            {
        //                Domicilio = new ComercioExteriorReceptorDomicilio { Calle = destino.Calle, NumeroExterior = destino.NumeroExterior, Localidad = destino.Localidad, Municipio = destino.Municipio, Estado = destino.CveEstado, Pais = destino.CvePais, CodigoPostal = destino.CodigoPostal },
        //                NumRegIdTrib = cliente.NumRegIdTrib
        //            };


        //            comercioExterior.Mercancias = new ComercioExteriorMercancia[detalle.Count];
        //            i = 0;
        //            foreach (var item in detalle)
        //            {
        //                comercioExterior.Mercancias[i] = new ComercioExteriorMercancia() { NoIdentificacion = item.CodigoProducto, FraccionArancelaria = item.CveFraccionArancelaria, CantidadAduana = (decimal)item.Kilogramos, UnidadAduana = "01", ValorUnitarioAduana = Math.Round(((decimal)item.Importe / (decimal)item.Kilogramos) * 1.00M, 2), ValorDolares = (decimal)item.Importe };
        //                i++;
        //            }

        //            cfdi.AgregarComplemento(comercioExterior);

        //            cfdi.Sello = selloDigital.Sellar(cfdi.CadenaOriginal());

        //            var timbrador = new Facturar();

        //            Respuesta res = await timbrador.TimbrarDev(cfdi.XMLString());


        //            if (res.EsCorrecto)
        //            {


        //                try
        //                {

        //                    string rutaXML = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot\\XMLs\\{cfdi.Serie + "-Prueba-" + cfdi.Folio}.xml");
        //                    string rutaPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot\\XMLs\\{cfdi.Serie + "-Prueba-" + cfdi.Folio}.pdf");

        //                    timbrador.GenerarArchivoXML(res.Data, rutaXML);
        //                    timbrador.GenerarPDF(res.Data, rutaPDF);

        //                    var obj = timbrador.LeerXML(rutaXML);

        //                    embarque.EstaTimbrado = true;
        //                    embarque.FolioFiscalDigital = obj.TimbreFiscalDigital.UUID;

        //                    _context.Embarque.Update(embarque);
        //                    await _context.SaveChangesAsync();


        //                    return new JsonResult(new { ExisteError = false, mensaje = "Se timbro correctamente" });
        //                }
        //                catch (Exception ex)
        //                {
        //                    return new JsonResult(new { ExisteError = true, mensaje = ex.Message });
        //                }
        //            }
        //            else
        //            {
        //                return new JsonResult(new { ExisteError = true, mensaje = "No se a timbrado -> " + res.Mensaje });
        //            }
        //        }
        //        else
        //        {
        //            return new JsonResult(new { ExisteError = true, mensaje = "No se a configurado el tipo de cambio para el dia de hoy" });
        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        return new JsonResult(new { ExisteError = true, mensaje = ex.Message });
        //    }
        //}


    }
}
