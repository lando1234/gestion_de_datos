using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FrbaOfertas.BaseDeDatos;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
namespace FrbaOfertas.ConectorDB
{
    class FuncionesUsername
    {
        public static int validarLogin(string username, string password)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("LOGIN_USUARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = password;

            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;


            
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

            

            return result;
        }
        public static void resetearCantidadDeLoginFallido(string username)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [NO_SRTA_E_GATOREI].USUARIOS SET LOGIN_FALLIDO = 0 WHERE USERNAME ='" + username + "'", con);
            cmd.ExecuteNonQuery();


        }
        public static void aumentarCantidadDeLoginFallido(string username)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE USUARIOS SET LOGIN_FALLIDO = LOGIN_FALLIDO + 1 WHERE USERNAME ='" + username +"'", con);
            cmd.ExecuteNonQuery();

        }

        public static int recuperarUsuarioId(string username, string pass)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].USUARIOS WHERE USERNAME ='" + username + "' AND PASS ='" + pass + "'", con);
            
            
            /*
            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;*/

            SqlDataReader registros = cmd.ExecuteReader();
            if (registros.HasRows)
            {
                while (registros.Read())
                {
                    result = registros.GetInt32(0);

                }

            }
            else {
                Console.WriteLine("EL usuario no existe");
            }
            //int result = (int)returnParameter.Value;
            registros.Close();
            return result;
            
        }

        public static List<String> ObtenerFuncionalidadesDeUnUsuario(string username)
        {
            List<String> lista = new List<String>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT r.NOMBRE FROM [NO_SRTA_E_GATOREI].USUARIOS u" +
            " INNER JOIN [NO_SRTA_E_GATOREI].USUARIOS_ROLES ur ON  u.USUARIO_ID = ur.USUARIO_ID" +
            " INNER JOIN [NO_SRTA_E_GATOREI].ROLES r ON ur.ROL_ID = r.ROL_ID WHERE u.USERNAME ='" + username + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            

            while (reader.Read())
            {

               lista.AddRange(FuncionesRol.ObtenerFuncionalidadesDeUnRol(reader["NOMBRE"].ToString()));

            }
            return lista;


        }
        public static Boolean existeUsername(string username)
        {
           SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].USUARIOS WHERE USERNAME ='" + username + "'", con);
            
            
            /*
            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;*/

            SqlDataReader registros = cmd.ExecuteReader();
            
            return registros.HasRows;
            
            
        }

        public static void GuardarUsuario(String usuario, String pass)
        {/*
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("LOGIN_USUARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = usuario;
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = pass;

            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            */
        }

        public static void insertarRolxUsuario( String username , String rol)
        {
           
        }

        public static void updatearUsuario(int id, string contraseña, Boolean habilitado, Boolean bloqueado)
        {
           
        }

        public static int getId(String username)
        {
            int id =0;
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].USUARIOS WHERE USERNAME ='" + username + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

               id = reader.GetInt32(0);

            }
            return id;
        }


        public static void BajaLogicaUsuario(int idUsuario)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [NO_SRTA_E_GATOREI].USUARIOS SET BAJA_LOGICA = 1 WHERE USUARIO_ID =" + idUsuario, con);
            cmd.ExecuteNonQuery();
        }

    }
}
