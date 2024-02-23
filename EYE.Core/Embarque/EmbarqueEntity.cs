using EYE.Dtos;
using EYE.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{



	[Table("Embarque")]
	public class EmbarqueEntity
	{
		public EmbarqueEntity()
		{

		}

		public EmbarqueEntity(EmbarqueDto obj)
		{
			IdEmbarque=obj.IdEmbarque;	
			Manifiesto=obj.Manifiesto;
			TipoEmbarque = obj.TipoEmbarque;
			IdCliente=obj.IdCliente;
			CAADES=obj.CAADES;
			IdAgenciaAduana=obj.IdAgenciaAduana;
			IdVehiculo=obj.IdVehiculo;	
			IdChofer=obj.IdChofer;
			IdRemolque=obj.IdRemolque;
			IdDestino=obj.IdDestino;
			Temperatura=obj.Temperatura;
			EstaActivo=true;
			EstaTimbrado = false;
		}

		[Key]
		public int IdEmbarque { get; set; }
		[Required]
		public int IdTemporada { get; set; }

		[Required]
		public int Manifiesto { get; set; }

		[Required]
		public TipoEmbarqueEnum TipoEmbarque { get; set; }
		[Required]
		public DateTime Fecha { get; set; }
		[Required]
		public int IdCliente { get; set; }
		[StringLength(8)]
		public string CAADES { get; set; }
		[Required]
		public int IdAgenciaAduana { get; set; }
		[Required]
		public int IdUsuario { get; set; }

		[Required]
		public int IdVehiculo { get; set; }
		[Required]
		public int IdChofer { get; set; }
		[Required]
		public int IdRemolque { get; set; }
		[Required]
		public int IdDestino { get; set; }
		[Required]
		public int Temperatura { get; set; }
		[StringLength(36)]
		public string FolioFiscalDigital { get; set; }

		[StringLength(10)]
		public string SelloPuesto { get; set; }
		[StringLength(10)]
		public string SelloRepuesto { get; set; }
		public bool EstaActivo { get; set; }

        public bool EstaTimbrado { get; set; }




		public int? IdBanco { get; set; }
		public DateTime? FechaPago { get; set; }

		[StringLength(20)]
		public string ReferenciaPago{ get; set; }

		public double Importe{ get; set; }

        public string Observaciones { get; set; }




        [ForeignKey("IdBanco")]
        public virtual BancoEntity Banco { get; set; }
        [ForeignKey("IdTemporada")]
		public virtual TemporadaEntity Temporada { get; set; }
		[ForeignKey("IdCliente")]
		public virtual ClienteEntity Cliente { get; set; }
		[ForeignKey("IdAgenciaAduana")]
		public virtual AgenciaAduanaEntity AgenciaAduana { get; set; }
		[ForeignKey("IdUsuario")]
		public virtual UsuarioEntity Usuario { get; set; }
		[ForeignKey("IdVehiculo")]
		public virtual VehiculoEntity Vehiculo { get; set; }
		[ForeignKey("IdChofer")]
		public virtual ChoferEntity Chofer { get; set; }
		[ForeignKey("IdRemolque")]
		
		public virtual RemolqueEntity Remolque { get; set; }
		[ForeignKey("IdDestino")]
		public virtual DestinoEntity Destino { get; set; }
		public virtual List<EmbarqueDetalleEntity> EmbarqueDetalle { get; set; }

	}
}
