using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Domain.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {

        [Key]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("NomUsuario")]
        public string NomUsuario { get; set; }

        [Column("Contrasenia")]
        public string Contrasenia { get; set; }

        [Column("Rol")]
        public string Rol { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

        [Column("FechaRegistro")]
        public DateTime FechaRegistro { get; set; }
    }
}
