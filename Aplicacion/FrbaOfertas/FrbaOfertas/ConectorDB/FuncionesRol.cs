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
        public static List<Rol> obtenerRoles()
        {
            List<Rol> lista = new List<Rol>();


            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            string sql = "SELECT R.*,P.* ";
                   sql += "FROM [NO_SRTA_E_GATOREI].ROLES R JOIN [NO_SRTA_E_GATOREI].PERMISOS_ROLES PR ";
                   sql += "ON R.ROL_ID = PR.ROL_ID ";
                   sql += "JOIN [NO_SRTA_E_GATOREI].PERMISOS P ON P.PERMISO_ID = PR.PERMISO_ID";
                   sql += "ORDER BY R.ROL_ID ASC";

                   SqlCommand cmd = new SqlCommand(sql);
                   SqlDataReader reader = cmd.ExecuteReader();
                   
                   reader.Read();
            
                   int rolId = (int) reader["ROL_ID"];       
                   Rol rol = new Rol(rolId, reader["NOMBRE"].ToString(), new List<Permiso>()); 
                    
                   while (reader.Read())
                   {
                       int nextId = (int) reader["ROL_ID"];
                       if (nextId != rolId)
                       {
                           lista.Add(rol);
                           rol = new Rol(nextId, reader["NOMBRE"].ToString(), new List<Permiso>()); 
                       }

                       rol.permisos.Add(new Permiso((int)reader["PERMISO_ID"], reader["PERMISO_DESC"].ToString(), reader["PERMISO_CLAVE"].ToString()));  

                   }
                   con.Close();
            return lista;

        }

        public static Rol obtenerRol(Nullable<int> rolId)
        {
            Rol rol = null;

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            string sql = "SELECT R.*,P.* ";
            sql += "FROM [NO_SRTA_E_GATOREI].ROLES R JOIN [NO_SRTA_E_GATOREI].PERMISOS_ROLES PR ";
            sql += "ON R.ROL_ID = PR.ROL_ID ";
            sql += "JOIN [NO_SRTA_E_GATOREI].PERMISOS P ON P.PERMISO_ID = PR.PERMISO_ID";
            sql += "WHERE R.ROL_ID = @ROL";


            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(new SqlParameter("@ROL",rolId));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                rol = new Rol(rolId, reader["NOMBRE"].ToString(), new List<Permiso>());

            
            while (reader.Read())
            {
                rol.permisos.Add(new Permiso((int)reader["PERMISO_ID"], reader["PERMISO_DESC"].ToString(), reader["PERMISO_CLAVE"].ToString()));

            }

            }
            con.Close();
            return rol;
        }

        public static List<Permiso> ObtenerFuncionalidades()
        {
            List<Permiso> lista = new List<Permiso>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [NO_SRTA_E_GATOREI].PERMISOS", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                   lista.Add(new Permiso((int) reader["PERMISO_ID"], reader["PERMISO_DESC"].ToString(),reader["PERMISO_CLAVE"].ToString()));
            }
            con.Close();
            return lista;

        }


        public static void GuardarRol(Rol rol)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CREAR_ROL", con);
            cmd.Parameters.AddWithValue("@ROL_DESC", rol.nombre);
            cmd.Parameters.AddWithValue("@Permisos", rol.getPermisos());
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void BajaLogicaRol(int idRol)
        {

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE ROLES SET BAJA_LOGICA = 1 WHERE ROL_ID =" + idRol, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void reactivarRol(int rolID)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE ROLES SET BAJA_LOGICA = 0 WHERE ROL_ID =" + rolID, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdatearRol(Rol rol)
        {
                        SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("ACTUALIZAR_ROL", con);
            cmd.Parameters.AddWithValue("@ROL_ID", rol.id);
            cmd.Parameters.AddWithValue("@ROL_DESC", rol.nombre);
            cmd.Parameters.AddWithValue("@Permisos", rol.getPermisos());
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}
