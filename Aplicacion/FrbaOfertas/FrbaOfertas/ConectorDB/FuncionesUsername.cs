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
using FrbaOfertas.Modelo;
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

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);

            returnParameter.Direction = ParameterDirection.ReturnValue;


            
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

            

            return result;
        }

        public static Usuario getUsuarioById(int id)
        {
            return null;
        }

        public static List<String> ObtenerFuncionalidadesDeUnUsuario(string username)
        {
            return null;

        }
        
        public static void updatearUsuario(int id, string contraseña, Boolean habilitado, Boolean bloqueado)
        {
           
        }

        public static void desbloquearUsuario(int id)
        {
           
        }

        public static void BajaLogicaUsuario(int id)
        {

        }

    }
}
