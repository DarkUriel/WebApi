using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String FechaCreacion { get; set; }
        public String Login { get; set; }
        public String Clave { get; set; }
        public String Estado { get; set; }
    }
}