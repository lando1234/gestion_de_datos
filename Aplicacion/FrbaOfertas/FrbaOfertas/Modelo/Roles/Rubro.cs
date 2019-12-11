using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    class Rubro
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public Rubro(int id, string decripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }
    }
}
