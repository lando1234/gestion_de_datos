using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Modelo.Roles;
using System.Data;
using FrbaOfertas.BaseDeDatos;
using System.Data.SqlClient;

namespace FrbaOfertas.ConectorDB
{
    class FuncionesRol
    {
        public static List<String> ObtenerFuncionalidadesDeUnRol(String nombreRol)
        {
            List<String> lista = new List<String>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT p.PERMISO_DESC FROM [NO_SRTA_E_GATOREI].ROLES r" +
            " INNER JOIN [NO_SRTA_E_GATOREI].PERMISOS_ROLES pr ON  r.ROL_ID = pr.ROL_ID"+
            " INNER JOIN [NO_SRTA_E_GATOREI].PERMISOS p ON pr.PERMISO_ID = p.PERMISO_ID WHERE r.NOMBRE ='" + nombreRol + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                lista.Add(reader["PERMISO_DESC"].ToString());

            }
            return lista;

        }

        public static List<String> ObtenerRolesDeUnUsuario(int idUsuario)
        {
            List<String> lista = new List<String>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT r.NOMBRE FROM [NO_SRTA_E_GATOREI].USUARIOS u" +
            " INNER JOIN [NO_SRTA_E_GATOREI].USUARIOS_ROLES ur ON  u.USUARIO_ID = ur.USUARIO_ID" +
            " INNER JOIN [NO_SRTA_E_GATOREI].ROLES r ON ur.ROL_ID = r.ROL_ID WHERE u.USUARIO_ID ='" + idUsuario + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
                lista.Add(reader["NOMBRE"].ToString());

            }
            return lista;



        }
        public static List<String> ObtenerFuncionalidades()
        {
            List<String> lista = new List<String>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PERMISO_DESC FROM [NO_SRTA_E_GATOREI].PERMISOS", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                lista.Add(reader["PERMISO_DESC"].ToString());

            }
            return lista;

        }

       
      

        public static Boolean ExisteRol(string rol)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE ='" + rol + "'", con);


            /*
            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;*/

            SqlDataReader registros = cmd.ExecuteReader();

            return registros.HasRows;

        }

        public static void GuardarRol(String Rol, List<String> listaFuncionalidades)
        {
          //ver  
        }

        public static void BajaLogicaRol(int idRol)
        {

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [NO_SRTA_E_GATOREI].ROLES SET BAJA_LOGICA = 1 WHERE ROL_ID =" + idRol, con);
            cmd.ExecuteNonQuery();

        }

        public static List<String> ObtenerRolesRegistrables() 
        {
            List<String> lista = new List<String>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT NOMBRE FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE <> 'ADMINISTRATIVO'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                lista.Add(reader["NOMBRE"].ToString());

            }
            return lista;
        }

        public static List<String> ObtenerRoles()
        {
            List<String> lista = new List<String>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT NOMBRE FROM [NO_SRTA_E_GATOREI].ROLES", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                lista.Add(reader["NOMBRE"].ToString());

            }
            return lista;
        }

        public static void invertirBajaLogicaRol(int rolID)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [NO_SRTA_E_GATOREI].ROLES SET BAJA_LOGICA = 0 WHERE ROL_ID =" + rolID, con);
            cmd.ExecuteNonQuery();
        }
        public static string ObtenerDetalleRol(int idRol)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT NOMBRE FROM [NO_SRTA_E_GATOREI].ROLES WHERE ROL_ID=" + idRol, con);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader["NOMBRE"].ToString();

        }


        public static Boolean ObtenerEstadoRol(int idRol)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT BAJA_LOGICA FROM [NO_SRTA_E_GATOREI].ROLES WHERE ROL_ID=" + idRol, con);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetInt16(reader.GetOrdinal("BAJA_LOGICA")) == 0;
        }

        public static void UpdatearRol(String RolNuevo, String Rol, bool habilitado, List<String> listaFunciones)
        {
            //TODO
        }
    }
}
