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
        public static int validLogin(string username, string password)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("LOGIN_USUARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@RESULT", SqlDbType.VarChar).Value = " ";

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;



            SqlDataReader registros = cmd.ExecuteReader();

            int result = (int)returnParameter.Value;

            while (registros.Read())
            {
                int returnParam = registros.GetInt16(0);

                if (returnParam < 0) {
                    result = returnParam;
                }

            }

            return result;
          
        }
        public static void resetearCant_login_Fallido(string username)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE USUARIOS SET LOGIN_FALLIDO = 0 WHERE USERNAME ='"+ username +"'", con);
            cmd.ExecuteNonQuery();


        }
        public static void aumentarCant_login_Fallido(string username)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE USUARIOS SET LOGIN_FALLIDO = LOGIN_FALLIDO + 1 WHERE USERNAME ='" + username +"'", con);
            cmd.ExecuteNonQuery();

        }

        public static int recuperar_usuario_id(string username, string pass)
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
            return null;

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
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("LOGIN_USUARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = usuario;
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = pass;

            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            
        }

        public static void insertarRolxUsuario(string Rol, string usuario)
        {
           
        }

        public static void updatearUsuario(int id, string contraseña, Boolean habilitado, Boolean bloqueado)
        {
           
        }

        public static int get_id(string username)
        {
            return -1;
        }

        public static void desbloquearUsuario(int id)
        {
           
        }

        public static void BajaLogicaUsuario(int id)
        {

        }

    }
}
