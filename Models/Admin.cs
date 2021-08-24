using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPITecsa.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
    }
}
