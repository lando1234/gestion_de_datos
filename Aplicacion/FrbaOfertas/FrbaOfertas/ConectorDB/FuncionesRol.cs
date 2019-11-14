using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.ConectorDB
{
    class FuncionesRol
    {
        public static List<String> ObtenerFuncionalidadesDeUnRol(string nombreRol)
        {
            List<String> lista = new List<string>();

            return lista;

        }

        public static List<String> ObtenerRolesDeUnUsuario(int id_usuario)
        {
            List<String> lista = new List<string>();
            return lista;



        }
        public static List<String> ObtenerRolesRegistrables()
        {
            List<String> lista = new List<string>();
            lista.Add("Proveedor");
            lista.Add("Cliente");
            lista.Add("Administrativo");
            return lista;

        }
        public static Boolean existeRol(string rol)
        {
            return false;

        }

        public static void GuardarRol(String Rol, List<String> listaFunciones)
        {

        }

        public static void BajaLogicaRol(int idRol)
        {

        }
        public static string ObtenerDetalleRol(int Id)
        {
            return "Error";

        }
        public static Boolean ObtenerEstadoRol(int Id)
        {
            return false;
        }

        public static void UpdatearRol(String RolNuevo, String Rol, bool habilitado, List<String> listaFunciones)
        {

        }
    }
}
