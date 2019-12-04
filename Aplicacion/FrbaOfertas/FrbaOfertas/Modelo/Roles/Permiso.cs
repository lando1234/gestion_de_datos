using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    class Permiso
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string clave { get; set; }

        public Permiso(int id, string descripcion, string clave)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.clave = clave;
        }

    }

}
