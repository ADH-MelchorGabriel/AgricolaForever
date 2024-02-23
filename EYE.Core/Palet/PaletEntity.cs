using EYE.Dtos;
using EYE.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
	[Table("Palet")]

	public class PaletEntity
	{
		public PaletEntity()
		{

		}
		public PaletEntity(PaletCompletoDto obj)
		{

			IdPalet = 0;
			Fecha=DateTime.Now;
			IdTemporada=obj.IdTemporada;
			IdEmpaque= obj.IdEmpaque;
			EsGaseado = obj.EsGaseado;
			EsPaletChep = obj.EsPaletChep;
			EstadoPalet = EstadoPaletEnum.Empacado;
			TipoPalet=TipoPaletEnum.Normal;
			EstaActivo = true;
		}
		
		[Key]
		public int IdPalet { get; set; }
		[Required]
		public int IdEmpaque { get; set; }

		[StringLength(40)]
		public string Folio { get; set; }
		[Required]
		public TipoPaletEnum TipoPalet{ get; set; }
		[Required]
		public DateTime Fecha { get; set; }
		[Required]
		public int IdTemporada { get; set; }
		public bool EsGaseado { get; set; }
		public bool EsPaletChep { get; set; }
		[Required]
		public EstadoPaletEnum EstadoPalet { get; set; }
		public bool EstaActivo { get; set; }
		[ForeignKey("IdEmpaque")]
		public virtual EmpaqueEntity Empaque{ get; set; }

	


		[ForeignKey("IdTemporada")]
		public virtual TemporadaEntity Temporada{ get; set; }

		public virtual List<PaletDetalleEntity> PaletDetalle { get; set; }
		public virtual List<EmbarqueDetalleEntity> EmbarqueDetalle { get; set; }

	}
}
