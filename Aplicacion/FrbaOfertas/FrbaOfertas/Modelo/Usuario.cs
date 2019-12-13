using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Modelo.Roles;

namespace FrbaOfertas.Modelo
{
    public class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Rol> roles { get; set; }

        public static void IngresoUsuario(string username, string pass)
        {
            FrbaOfertas.ConectorDB.FuncionesUsername.recuperar_usuario_id(username, pass);

        }
    }
}
