using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    class Factura
    {
        public int id { get; set; }
        public Int64 numero { get; set; }
        public DateTime fecha { get; set; }
        public double importe { get; set; }

        public Factura(Int64 numero, double importe)
        {
            this.numero = numero;
            this.importe = importe;
        }
    }
}
