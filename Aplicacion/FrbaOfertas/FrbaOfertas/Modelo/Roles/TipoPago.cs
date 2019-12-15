using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    class TipoPago
    {
        public int id { get; set; }
        public string descripcion { get; set; }


        public TipoPago(int id, string descripcion) {

            this.id = id;
            this.descripcion = descripcion;
        }

        public override string ToString()
        {
            return descripcion;
        }
}
    }

   
