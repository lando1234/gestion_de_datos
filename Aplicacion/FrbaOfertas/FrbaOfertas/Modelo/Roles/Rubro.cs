using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    public class Rubro
    {
        public Nullable<int> id { get; set; }
        public string descripcion { get; set; }

        public Rubro(Nullable<int> id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }


        public override string ToString() {
            return this.descripcion;
        }
    }
}
