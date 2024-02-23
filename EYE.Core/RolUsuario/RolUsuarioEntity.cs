using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
	public class RolUsuarioEntity
	{
		[Key]
		public int IdRolUsuario { get; set; }
		[Required]
		public int IdRol { get; set; }
		[Required]
		public int IdUsuario { get; set; }

		public bool EstaActivo { get; set; }
		[ForeignKey("IdRol")]
		public virtual RolEntity Rol { get; set; }
		[ForeignKey("IdUsuario")]
		public virtual UsuarioEntity Usuario { get; set; }
	}
}
