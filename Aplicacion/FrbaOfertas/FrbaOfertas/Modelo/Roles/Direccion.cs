using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    public class Direccion
    {
        public Nullable<int> id { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public Nullable<decimal> codigoPostal { get; set; }

        public Direccion(Nullable<int> id, string ciudad, string calle, Nullable<decimal> codigoPostal)
        {
            this.id = id;
            this.Ciudad = ciudad;
            this.Calle = calle;
            this.codigoPostal = codigoPostal;
        }
    }
}
