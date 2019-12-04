using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    public class Rol
    {
        public IList<Permiso> permisos {get; set; };
        public String nombre { get; set; }
        public int id { get; set; }

        public Rol(){ }

        public Rol(int id, string nombre, List<Permiso> permisos)
        {
            this.id = id;
            this.nombre = nombre;
            this.permisos = permisos;
        }

        public void Instertar()
        {
        }
        public void Modificar() 
        {
        }

        public String getPermisos()
        {
           string result = "";
            foreach (Permiso p in permisos){
                result += p.id + "|";
            }

            return result.Substring(0,result.Length - 1);
        }

    }
}
