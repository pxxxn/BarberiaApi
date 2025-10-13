using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Domain.DTOs
{
    public class LoginRequest
    {
        public string NomUsuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
