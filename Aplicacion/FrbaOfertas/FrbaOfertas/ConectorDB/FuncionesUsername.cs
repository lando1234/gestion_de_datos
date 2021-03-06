﻿using System;
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
using System.Security.Cryptography;
using FrbaOfertas.Modelo.Roles;
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
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = ComputeSha256Hash(password);
            cmd.Parameters.Add("@RESULT", SqlDbType.Int).Direction = ParameterDirection.Output;

            var returnParameter = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            
          
           //SqlDataReader registros = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();

           int returnValue = (int)returnParameter.Value;

            if (returnValue == 0) {
             returnValue = Convert.ToInt16(cmd.Parameters["@RESULT"].Value);
            }

            con.Close();
            return returnValue;
          
        }
        
        public static Usuario getUserById(int usuario_id) {

            Usuario usuario = new Usuario();
            usuario.roles = new List<Rol>();
            
            
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            String sql = "SELECT u.USERNAME, ur.ROL_ID FROM [NO_SRTA_E_GATOREI].USUARIOS u INNER JOIN [NO_SRTA_E_GATOREI].USUARIOS_ROLES ur ON u.USUARIO_ID = ur.USUARIO_ID ";
            sql += "WHERE u.USUARIO_ID = @USUARIO_ID";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@USUARIO_ID", usuario_id));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                if (usuario.username == null)
                {
                    usuario.id = usuario_id;

                    usuario.username = reader.GetString(reader.GetOrdinal("USERNAME"));
                }
                usuario.roles.Add(FuncionesRol.obtenerRol(reader.GetInt32(reader.GetOrdinal("ROL_ID"))));


            }
              con.Close();
            return usuario;
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

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString().ToLower();
            }
        }  

    }
}
