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
            SqlCommand cmd = new SqlCommand("LOGIN", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = password;

            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;


            
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

            return result;
        }
        public static void resetearCant_login_Fallido(string username)
        {
            //SqlConnection conn = new SqlConnection(Conexion.getStringConnection());
            //SqlCommand command = conn.CreateCommand();
            //command.CommandText = "HPBC.pr_resetear_cant_login_fallido";
            //command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = username;
            //command.Connection = conn;
            //command.Connection.Open();
            //command.ExecuteNonQuery();
            //command.Connection.Close();
            //conn.Close();

        }
        public static void aumentarCant_login_Fallido(string username)
        {
           

        }

        public static void recuperar_usuario_id(string username, string pass)
        {

            
        }

        public static List<String> ObtenerFuncionalidadesDeUnUsuario(string username)
        {
            return null;

        }
        public static Boolean existeUsername(string username)
        {
            return false;
        }

        public static void GuardarUsuario(String usuario, String pass)
        {
            
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
