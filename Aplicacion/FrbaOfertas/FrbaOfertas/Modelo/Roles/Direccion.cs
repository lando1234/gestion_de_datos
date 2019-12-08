using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    class Direccion
    {
        public int id { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public string codigoPostal { get; set; }
        public string Piso { get; set; }
        public string Dpto { get; set; }
        public string Localidad { get; set; }

        public Direccion(int id, string ciudad, string calle, string codigoPostal)
        {
            this.id = id;
            this.Ciudad = ciudad;
            this.Calle = calle;
            this.codigoPostal = codigoPostal;
        }
    }
}
