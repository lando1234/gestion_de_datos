using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Modelo.Roles;
using FrbaOfertas.Modelo;
using System.Data;
using FrbaOfertas.BaseDeDatos;
using System.Data.SqlClient;

namespace FrbaOfertas.ConectorDB
{
    class FuncionesProveedor
    {
        public static int altaUsuarioProveedor(Proveedor proveedor, Usuario usuario)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CREAR_USUARIO_PROVEEDOR", con);
            
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = usuario.username;
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = usuario.password;
            cmd.Parameters.Add("@RS", SqlDbType.VarChar).Value = proveedor.RazonSocial;
            cmd.Parameters.Add("@CUIT", SqlDbType.VarChar).Value = proveedor.cuit;
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = proveedor.mail;
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = proveedor.telefono;
            cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = proveedor.direccion.Calle;
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = proveedor.direccion.codigoPostal;
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = proveedor.direccion.Ciudad;
            cmd.Parameters.Add("@RUBRO_ID", SqlDbType.VarChar).Value = proveedor.rubro.id;
            cmd.Parameters.Add("@NOMBRE_CONTACTO", SqlDbType.VarChar).Value = proveedor.nombreContacto;

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;


            
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;
            con.Close();
            return result;

        }

        public static int altaProveedor(Proveedor proveedor)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CREAR_PROVEEDOR", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@RS", SqlDbType.VarChar).Value = proveedor.RazonSocial;
            cmd.Parameters.Add("@CUIT", SqlDbType.VarChar).Value = proveedor.cuit;
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = proveedor.mail;
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = proveedor.telefono;
            cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = proveedor.direccion.Calle;
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = proveedor.direccion.codigoPostal;
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = proveedor.direccion.Ciudad;
            cmd.Parameters.Add("@RUBRO_ID", SqlDbType.VarChar).Value = proveedor.rubro.id;
            cmd.Parameters.Add("@NOMBRE_CONTACTO", SqlDbType.VarChar).Value = proveedor.nombreContacto;

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;



            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;
            con.Close();
            return result;

        }

        public static void editProveedor(Proveedor proveedor)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            
            SqlCommand cmd = new SqlCommand("CREAR_PROVEEDOR", con);

            string sql = "UPDATE [NO_SRTA_E_GATOREI].[PROVEEDORES] "
                   sql += "SET [CUIT] = @CUIT ";
                   sql += ",[RAZON_SOCIAL] = @RS ";
                   sql += ",[NOMBRE_CONTACTO] = @NOMBRE_CONTACTO ";
                   sql += ",[RUBRO_ID] = @RUBRO ";
                   sql += ",[MAIL] = @MAIL ";
                   sql += ",[TELEFONO] = @TELEFONO  ";
                   sql += "WHERE PROVEEDOR_ID = @ID ";

            cmd.Parameters.Add("@RS", SqlDbType.VarChar).Value = proveedor.RazonSocial;
            cmd.Parameters.Add("@CUIT", SqlDbType.VarChar).Value = proveedor.cuit;
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = proveedor.mail;
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = proveedor.telefono;
            cmd.Parameters.Add("@RUBRO", SqlDbType.VarChar).Value = proveedor.rubro.id;
            cmd.Parameters.Add("@NOMBRE_CONTACTO", SqlDbType.VarChar).Value = proveedor.nombreContacto;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = proveedor.id;

            

            cmd.ExecuteNonQuery();

            con.Close();

        }

        
        public static void invertirBajaLogicaProveedor(Proveedor proveedor)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("INVERTIR_BAJA_LOGICA_PROVEEDOR", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PROVEEDOR_ID", SqlDbType.VarChar).Value = proveedor.id;

            
            cmd.ExecuteNonQuery();
            con.Close();
        }
    

        public static void crearRubro(string Rubro)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [NO_SRTA_E_GATOREI].RUBROS(DESCRIPCION) VALUES (@RUBRO)", con);

            cmd.Parameters.Add("@RUBRO", SqlDbType.VarChar).Value = Rubro;


            cmd.ExecuteNonQuery();
            con.Close();
        }

}
