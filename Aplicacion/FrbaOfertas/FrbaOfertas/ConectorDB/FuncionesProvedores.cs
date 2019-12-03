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
    class FuncionesProveedor
    {
        public static int altaProveedor(Proveedor proveedor, String username, String password)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CREAR_USUARIO_PROVEEDOR", con);
            
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@RS", SqlDbType.VarChar).Value = proveedor.RazonSocial;
            cmd.Parameters.Add("@CUIT", SqlDbType.VarChar).Value = proveedor.cuit;
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = proveedor.mail;
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = proveedor.telefono;
            cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = proveedor.Calle;
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = proveedor.codigoPostal;
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = proveedor.Ciudad;
            cmd.Parameters.Add("@RUBRO", SqlDbType.VarChar).Value = proveedor.rubro;
            cmd.Parameters.Add("@NOMBRE_CONTACTO", SqlDbType.VarChar).Value = proveedor.nombreContacto;

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;


            
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

            return result;

        }
/*
        public static Boolean facturarProveedor(int proveedorID, DateTime fechaDesde, DateTime fechaHasta ,Factura factura)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            SqlCommand cmd = new SqlCommand("FACTURAR_PROVEEDOR", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PROVEEDOR_ID", SqlDbType.VarChar).Value = proveedorID;
            cmd.Parameters.Add("@NUMERO_FACTURA", SqlDbType.VarChar).Value = factura.numero;
            cmd.Parameters.Add("@FECHA_DESDE", SqlDbType.VarChar).Value = fechaDesde;
            cmd.Parameters.Add("@FECHA_HASTA", SqlDbType.VarChar).Value = fechaHasta;
            cmd.Parameters.Add("@FECHA_FACTURACION", SqlDbType.VarChar).Value = factura.fecha;

            con.Open();
            cmd.ExecuteNonQuery();

            return false;
        }
 */
        public static void BajaLogicaProveedor(int proveedorID)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE PROVEEDORES SET BAJA_LOGICA = 1 WHERE PROVEEDOR_ID =" + proveedorID, con);
            cmd.ExecuteNonQuery();

        }
        public static void invertirBajaLogicaProveedor(int proveedorID)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("INVERTIR_BAJA_LOGICA_PROVEEDOR", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PROVEEDOR_ID", SqlDbType.VarChar).Value = proveedorID;

            
            cmd.ExecuteNonQuery();
        }
    

        public static void crearRubro(string Rubro)
        {

        }

        public static Boolean existeRubro(string rubro)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].PROVEEDORES WHERE RUBRO ='" + rubro + "'", con);


            /*
            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;*/

            SqlDataReader registros = cmd.ExecuteReader();

            return registros.HasRows;
        }


    }
}
