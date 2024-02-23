using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
	[Table("Usuario")]
	public class UsuarioEntity
	{
		[Key]
		public int IdUsuario { get; set; }
		[Required]
		[StringLength(120)]
		public string UserName { get; set; }
		[Required]
		[StringLength(300)]
		public string Password { get; set; }
		[Required]
		[StringLength(90)]
		public string Nombre { get; set; }
		
		[StringLength(120)]
		public string Correo { get; set; }
		public bool EstaActivo { get; set; }	

		public virtual List<EmbarqueEntity> Embarque { get; set; }
		public virtual List<RolUsuarioEntity> RolUsuario { get; set; }


	}
}
