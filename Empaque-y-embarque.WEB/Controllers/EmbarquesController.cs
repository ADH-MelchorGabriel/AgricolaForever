using EYE.Dtos;
using EYE.Entidades;
using EYE.Enumeradores;
using EYE.Servicio.Data;
using EYE.Vistas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class EmbarquesController : Controller
    {
        private readonly EyeContext _context;
        public EmbarquesController(EyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Nuevo()
        {
            return View();
        }
        [HttpGet]
        [Route("/Embarques/nuevo/Buscar")]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {
            var obj = await _context.Embarque
                                    .Include(x => x.Vehiculo)
                                    .Where(x => x.EstaActivo && x.IdEmbarque == id)
                                    .Select(x => new { x.IdEmbarque, x.Manifiesto, x.TipoEmbarque, x.IdCliente, x.Vehiculo.IdLineaTransporte, x.CAADES, x.IdAgenciaAduana, x.IdVehiculo, x.IdChofer, x.IdRemolque, x.IdDestino, x.Temperatura, x.EstaTimbrado })
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        [Route("/Embarques/nuevo/BuscarDetalle")]
        public async Task<JsonResult> BuscarDetalle([FromQuery] int id)
        {
            var obj = await _context.EmbarqueDetalle
                                    .Where(x => x.IdEmbarqueDetalle == id)
                                    .Select(x => new { x.IdEmbarqueDetalle, x.Posicion, x.IdPalet })
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        [Route("/Embarques/nuevo/BuscarSellos")]
        public async Task<JsonResult> BuscarSellos([FromQuery] int id)
        {
            SellosDto obj = await _context.Embarque
                                    .Where(x => x.EstaActivo && x.IdEmbarque == id)
                                    .Select(x => new SellosDto { SelloPuesto = x.SelloPuesto, SelloRepuesto = x.SelloRepuesto })
                                    .FirstOrDefaultAsync();

            obj ??= new SellosDto();

            return new JsonResult(obj);
        }
        [HttpGet]
        [Route("/Embarques/nuevo/ListarDetalle")]
        public async Task<JsonResult> ListarDetalle([FromQuery] int id)
        {
            var obj = await _context.EmbarqueDetalle
                                    .Include(x => x.Palet)
                                    .ThenInclude(x => x.PaletDetalle)
                                    .ThenInclude(x => x.Producto)
                                    .Where(x => x.IdEmbarque == id)
                                    .Select(x => new { x.IdEmbarqueDetalle, x.Posicion, x.IdPalet, x.Palet.Folio, Productos = x.Palet.PaletDetalle.Select(y => new { Producto = y.Producto.Nombre, y.Cantidad }) })
                                    .ToListAsync();

            return new JsonResult(obj.OrderBy(x => x.Posicion).ToList());
        }
        public async Task<JsonResult> Listar()
        {
            var temporada = await _context.Temporadas.Where(x => x.FechaFinal.Date >= DateTime.Now && x.FechaInicio.Date <= DateTime.Now).FirstOrDefaultAsync();


            var lista = await _context.Embarque
                                      .Include(x => x.Cliente)
                                      .Where(x => x.EstaActivo && x.IdTemporada == temporada.IdTemporada)
                                      .Select(x => new { x.IdEmbarque, x.Manifiesto, x.Fecha, Cliente = x.Cliente.Nombre })
                                      .OrderByDescending(x => x.Manifiesto)
                                      .ToListAsync();

            return new JsonResult(lista);
        }
        [HttpPost]
        [Route("/Embarques/nuevo/Guardar")]
        public async Task<JsonResult> Guardar([FromBody] EmbarqueDto newObj)
        {
            try
            {
                _context.Database.BeginTransaction();

                var temporada = await _context.Temporadas.Where(x => x.FechaFinal.Date >= DateTime.Now && x.FechaInicio.Date <= DateTime.Now).FirstOrDefaultAsync();

                var embarque = new EmbarqueEntity(newObj)
                {
                    IdTemporada = temporada.IdTemporada,
                    Fecha = DateTime.Now,
                    //todo:cambiar por el usuario loguedo
                    IdUsuario = 1
                };
                if (embarque.IdEmbarque == 0)
                {
                    embarque.Manifiesto = GetSiguienteManifiesto(temporada.IdTemporada);
                    await _context.Embarque.AddAsync(embarque);
                }
                else
                {
                    _context.Embarque.Update(embarque);
                }
                await _context.SaveChangesAsync();
                newObj.IdEmbarque = embarque.IdEmbarque;
                newObj.Manifiesto = embarque.Manifiesto;
                _context.Database.CommitTransaction();
                return new JsonResult(newObj);
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                return new JsonResult(null);
            }
        }
        [HttpPost]
        [Route("/Embarques/nuevo/GuardarDetalle")]
        public async Task<JsonResult> GuardarDetalle([FromBody] EmbarqueDetalleDto newObj, [FromQuery] int id)
        {
            try
            {
                _context.Database.BeginTransaction();

                var detalle = new EmbarqueDetalleEntity(newObj)
                {
                    IdEmbarque = id,
                    //todo: configuracion de precio
                    Precio = 4,
                    EsSobrePeso = false
                };

                if (detalle.IdEmbarqueDetalle == 0)
                {
                    await _context.EmbarqueDetalle.AddAsync(detalle);
                    newObj.IdEmbarqueDetalle = detalle.IdEmbarqueDetalle;
                }
                else
                {
                    _context.EmbarqueDetalle.Update(detalle);
                }

                await _context.SaveChangesAsync();


                var palet = await _context.Palet.Where(x => x.IdPalet == detalle.IdPalet).FirstOrDefaultAsync();

                palet.EstadoPalet = EstadoPaletEnum.Embarcado;

                _context.Palet.Update(palet);
                await _context.SaveChangesAsync();
                _context.Database.CommitTransaction();
                return new JsonResult(newObj);
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                return new JsonResult(null);
            }
        }
        [HttpPost]
        [Route("/Embarques/nuevo/GuardarSellos")]
        public async Task<JsonResult> GuardarSellos([FromBody] SellosDto newObj, [FromQuery] int id)
        {
            try
            {
                _context.Database.BeginTransaction();

                var embarque = await _context.Embarque.Where(x => x.IdEmbarque == id).FirstOrDefaultAsync();

                embarque.SelloPuesto = newObj.SelloPuesto;
                embarque.SelloRepuesto = newObj.SelloRepuesto;

                _context.Embarque.Update(embarque);
                await _context.SaveChangesAsync();

                _context.Database.CommitTransaction();
                return new JsonResult(newObj);
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                return new JsonResult(null);
            }
        }

        [HttpGet]
        [Route("/Embarques/nuevo/BorrarDetalle")]
        public async Task<JsonResult> BorrarDetalle([FromQuery] int id)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                var borrar = await _context.EmbarqueDetalle.Where(x => x.IdEmbarqueDetalle == id).FirstOrDefaultAsync();

                _context.EmbarqueDetalle.Remove(borrar);
                await _context.SaveChangesAsync();

                var palet = await _context.Palet.Where(x => x.IdPalet == borrar.IdPalet).FirstOrDefaultAsync();

                palet.EstadoPalet = EstadoPaletEnum.Empacado;

                _context.Palet.Update(palet);
                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
                return new JsonResult(borrar);
            }
            catch (Exception)
            {
                await _context.Database.RollbackTransactionAsync();
                return new JsonResult(null);
            }



        }
        private int GetSiguienteManifiesto(int idTemporada)
        {
            var resultado = 1;
            try
            {
                resultado = _context.Embarque.Where(x => x.IdTemporada == idTemporada).Max(x => x.Manifiesto) + 1;
                return resultado;
            }
            catch (Exception)
            {
                resultado = 1;
                return resultado;
            }
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetClientes")]
        public async Task<JsonResult> GetClientes()
        {
            var lista = await _context.Clientes.Where(x => x.EstaActivo == true).Select(x => new { x.IdCliente, x.Nombre, }).ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetBancos")]
        public async Task<JsonResult> GetBancos()
        {
            var lista = await _context.Bancos.Where(x => x.EstaActivo == true).Select(x => new { x.IdBanco, x.Nombre, }).ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetAgenciaAduanal")]
        public async Task<JsonResult> GetAgenciaAduanal()
        {
            var lista = await _context.AgenciaAduanas.Where(x => x.EstaActivo == true).Select(x => new { x.IdAgenciaAduana, x.Nombre, }).ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetLineasTransportes")]
        public async Task<JsonResult> GetLineasTransportes()
        {
            var lista = await _context.LineaTransportes.Where(x => x.EstaActivo == true).Select(x => new { x.IdLineaTransporte, x.Nombre, }).ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetVehiculos")]
        public async Task<JsonResult> GetVehiculos([FromQuery] int id)
        {
            var lista = await _context.Vehiculos.Where(x => x.IdLineaTransporte == id && x.EstaActivo == true).Select(x => new { x.IdVehiculo, Nombre = x.Descripcion + ' ' + x.Placas }).ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetRemolques")]
        public async Task<JsonResult> GetRemolques([FromQuery] int id)
        {
            var lista = await _context.Remolques.Where(x => x.IdLineaTransporte == id && x.EstaActivo == true).Select(x => new { x.IdRemolque, Nombre = x.Descripcion + ' ' + x.Placas }).ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetChoferes")]
        public async Task<JsonResult> GetChoferes([FromQuery] int id)
        {
            var lista = await _context.Choferes.Where(x => x.IdLineaTransporte == id && x.EstaActivo == true).Select(x => new { x.IdChofer, x.Nombre }).ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetDestinos")]
        public async Task<JsonResult> GetDestinos()
        {
            var lista = await _context.Destinos.Where(x => x.EstaActivo == true).Select(x => new { x.IdDestino, Nombre = x.Calle + ",No. " + x.NumeroExterior + ", " + x.Localidad + ", " + x.Municipio + ", " + x.CveEstado + ", " + x.CvePais + ", cp" + x.CodigoPostal }).ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetPalets")]
        public async Task<JsonResult> GetPalets()
        {
            var temporada = await _context.Temporadas.Where(x => x.FechaFinal.Date >= DateTime.Now && x.FechaInicio.Date <= DateTime.Now).FirstOrDefaultAsync();


            var lista = await _context.Palet
                                      .Where(x => x.EstaActivo == true && x.IdTemporada == temporada.IdTemporada && x.EstadoPalet == EstadoPaletEnum.Empacado)
                                      .Select(x => new { x.IdPalet, Nombre = x.Folio })
                                      .ToListAsync();
            return new JsonResult(lista.OrderBy(x => x.IdPalet).ToList());
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetTipoEmbarque")]
        public JsonResult GetTipoEmbarque()
        {
            var lista = Enum.GetValues(typeof(TipoEmbarqueEnum))
                   .Cast<TipoEmbarqueEnum>()
                   .Select(d => new { display = d.ToString(), value = (int)d })
                   .ToList();
            return new JsonResult(lista);
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetCartaSellos")]
        public async Task<JsonResult> GetCartaSellos([FromQuery] int id)
        {

            var obj = await _context.Embarque
                                     .Include(x => x.Vehiculo)
                                     .Include(x => x.Remolque)
                                     .Include(x => x.Chofer)
                                    .Where(x => x.IdEmbarque == id)
                                    .Select(x => new { x.IdEmbarque, x.Manifiesto, Fecha = x.Fecha.ToString("dd/MM/yyyy"), Hora = x.Fecha.ToString("hh:mm:ss tt"), Camion = x.Vehiculo.Descripcion + ' ' + x.Vehiculo.Placas, Remolque = x.Remolque.Descripcion + ' ' + x.Remolque.Placas, Chofer = x.Chofer.Nombre, x.SelloPuesto, x.SelloRepuesto })
                                    .FirstOrDefaultAsync();


            return new JsonResult(obj);
        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetCartaResponsiva")]
        public async Task<JsonResult> GetCartaResponsiva([FromQuery] int id)
        {

            try
            {
                var obj = await _context.Embarque
                                   .Include(x => x.Cliente)
                                   .Include(x => x.Destino)
                                   .Include(x => x.Vehiculo)
                                   .Include(x => x.Remolque)
                                   .Include(x => x.Chofer)
                                   .ThenInclude(x => x.LineaTransportes)
                                   .Where(x => x.IdEmbarque == id)
                                   .Select(x => new
                                   {
                                       x.Manifiesto,
                                       Chofer = x.Chofer.Nombre,
                                       Camion = x.Vehiculo.Descripcion + ' ' + x.Vehiculo.Placas,
                                       x.Vehiculo.Año,
                                       Remolque = x.Remolque.Descripcion,
                                       Propietario = x.Chofer.LineaTransportes.Nombre,
                                       Cliente = x.Cliente.Nombre,
                                       x.Destino.Direccion,
                                       Fecha = x.Fecha.ToString("dddd, dd MMMM yyyy"),
                                       Detalle = new List<EmbarqueDetalleAgrupadoView>()
                                   })
                                   .FirstOrDefaultAsync();


                var Detalle = _context.EmbarqueDetalleAgrupadoView.Where(y => y.IdEmbarque == id).ToList();

                foreach (var item in Detalle)
                {
                    obj.Detalle.Add(item);
                }

                return new JsonResult(obj);
            }
            catch (Exception es)
            {

                var c = es.Message;
                return new JsonResult(null);
            }


        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetGuia")]
        public async Task<JsonResult> GetGuia([FromQuery] int id)
        {

            var obj = await _context.Embarque
                                    .Include(x => x.Cliente)
                                    .Include(x => x.Destino)
                                    .Include(x => x.AgenciaAduana)
                                    .Include(x => x.Vehiculo)
                                    .Include(x => x.Remolque)
                                    .Include(x => x.Chofer)
                                    .Where(x => x.IdEmbarque == id)
                                    .Select(x => new
                                    {
                                        x.IdEmbarque,
                                        Fecha = x.Fecha.ToString("dd          MM          yy"),
                                        Cliente = x.Cliente.Nombre,
                                        DireccionCliente = x.Destino.NumeroExterior + " " + x.Destino.Calle + ", " + x.Destino.Localidad + ", " + x.Destino.CveEstado + " " + x.Destino.CodigoPostal,
                                        AgenciaAduanal = x.AgenciaAduana.Nombre,
                                        Vehiculo = x.Vehiculo.Descripcion,
                                        x.Vehiculo.Año,
                                        x.Vehiculo.Placas,
                                        Remolque = x.Remolque.Descripcion,
                                        Chofer = x.Chofer.Nombre,
                                        Detalle = new List<EmbarqueDetalleGuiaView>()

                                    })
                                    .FirstOrDefaultAsync();

            var Detalle = _context.EmbarqueDetalleGuiaView.Where(y => y.IdEmbarque == id).ToList();

            foreach (var item in Detalle)
            {
                obj.Detalle.Add(item);
            }


            return new JsonResult(obj);
        }

        [HttpGet]
        [Route("/Embarques/nuevo/GetManifiesto")]
        public async Task<JsonResult> GetManifiesto([FromQuery] int id)
        {
            try
            {
                var obj = await _context.Embarque
                                        .Include(x => x.Cliente)
                                        .Include(x => x.Destino)
                                        .Include(x => x.Vehiculo)
                                        .Include(x => x.Remolque)
                                        .Include(x => x.Chofer)
                                        .ThenInclude(x => x.LineaTransportes)
                                        .Where(x => x.IdEmbarque == id)
                                        .Select(x => new
                                        {
                                            x.Manifiesto,
                                            Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                                            Hora = x.Fecha.ToString("hh:mm:ss tt"),
                                            Cliente = x.Cliente.Nombre,
                                            DireccionCliente = x.Destino.Calle + " " + x.Destino.NumeroExterior + ", " + x.Destino.Localidad + ", " + x.Destino.CveEstado + " " + x.Destino.CodigoPostal,
                                            Propietario = x.Chofer.LineaTransportes.Nombre,
                                            Vehiculo = x.Vehiculo.Descripcion,
                                            x.Vehiculo.Placas,
                                            Remolque = x.Remolque.Descripcion,
                                            PlacasRemolque = x.Remolque.Placas,
                                            Chofer = x.Chofer.Nombre,
                                            SelloPuesto = x.SelloPuesto ?? "",
                                            SelloRepuesto = x.SelloRepuesto ?? "",
                                            x.Temperatura,
                                            Detalle = new List<EmbarqueDetalleManifiestoView>()
                                        })
                                        .FirstOrDefaultAsync();



                var Detalle = _context.EmbarqueDetalleManifiestoView
                                      .Where(y => y.IdEmbarque == id)
                                      //        .Select(x=> new {x.IdEmbarque, x.Producto,x.Tamaño,x.Envase,x.Calidad,x.cantidad,x.Kilos })
                                      .ToList();

                foreach (var item in Detalle)
                {

                    obj.Detalle.Add(item);
                }

                return new JsonResult(obj);

            }
            catch (Exception)
            {

                return new JsonResult(null);
            }


        }
        [HttpGet]
        [Route("/Embarques/nuevo/GetManifiestoDetallado")]

        public async Task<JsonResult> GetManifiestoDetallado([FromQuery] int id)
        {
            try
            {
                var obj = await _context.Embarque
                                        .Include(x => x.Cliente)
                                        .Include(x => x.Destino)
                                        .Where(x => x.IdEmbarque == id)
                                        .Select(x => new
                                        {
                                            x.Manifiesto,
                                            Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                                            Hora = x.Fecha.ToString("hh:mm:ss tt"),
                                            Cliente = x.Cliente.Nombre,
                                            DireccionCliente = x.Destino.Calle + " " + x.Destino.NumeroExterior + ", " + x.Destino.Localidad + ", " + x.Destino.CveEstado + " " + x.Destino.CodigoPostal,
                                            Detalle = new List<EmbarqueDetallePosicionView>()
                                        })
                                        .FirstOrDefaultAsync();



                var Detalle = _context.EmbarqueDetallePosicionView
                                      .Where(y => y.IdEmbarque == id)
                                      .OrderBy(x=> x.Posicion)
                                      .ToList();

                foreach (var item in Detalle)
                {

                    obj.Detalle.Add(item);
                }

                return new JsonResult(obj);

            }
            catch (Exception)
            {

                return new JsonResult(null);
            }


        }



    }
}
