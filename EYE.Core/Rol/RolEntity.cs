using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
	[Table("Rol")]
	public class RolEntity
	{
		[Key]
		public int IdRol { get; set; }
		[StringLength(60)]
		public string Nombre { get; set; }	
		public bool EstaActivo { get; set; }
		public virtual List<RolUsuarioEntity> RolUsuario { get; set; }
	}
}
