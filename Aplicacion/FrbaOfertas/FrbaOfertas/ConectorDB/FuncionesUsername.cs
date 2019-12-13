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
        
        public static Usuario getUserById(int usuario_id) {

            Usuario usuario = new Usuario();
            
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            String sql = "SELECT u.USERNAME, ur.ROL_ID FROM [NO_SRTA_E_GATOREI].USUARIOS u INNER JOIN [NO_SRTA_E_GATOREI].USUARIOS_ROLES ur ON u.USUARIO_ID = ur.USUARIO_ID ";
            sql += "WHERE u.USUARIO_ID = @USUARIO_ID";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(new SqlParameter("@USUARIO_ID", usuario_id));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                if (usuario.username == null)
                {
                    usuario.id = usuario_id;
                    usuario.username = reader.GetString(reader.GetOrdinal("USERNAME"));
                }
                usuario.roles.Add(FuncionesRol.obtenerRol(reader.GetInt16(reader.GetOrdinal("ROL_ID"))));


            }

            return usuario;
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
