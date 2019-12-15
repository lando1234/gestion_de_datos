using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    class Proveedor
    {
        public int id { get; set; }
        public string RazonSocial { get; set; }
        public string cuit { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public Direccion direccion { get; set; }
        public Rubro rubro { get; set; }
        public string nombreContacto { get; set; }
        public bool habilitado { get; set; }

    }
}
