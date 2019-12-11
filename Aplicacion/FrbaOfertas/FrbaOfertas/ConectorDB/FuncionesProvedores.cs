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

            string sql = "UPDATE [NO_SRTA_E_GATOREI].[PROVEEDORES] ";
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
        public static IList<Proveedor> getProveedores()
        {
            String sql = "SELECT P.[PROVEEDOR_ID],P.[CUIT],P.[RAZON_SOCIAL],P.[NOMBRE_CONTACTO],P.[MAIL],P.[TELEFONO],P.[BAJA_LOGICA],R.*, D.* ";
            sql += "FROM NO_SRTA_E_GATOREI.PROVEEDORES P ";
            sql += "INNER JOIN NO_SRTA_E_GATOREI.RUBROS R ON P.RUBRO_ID = R.RUBRO_ID";
            sql += "INNER JOIN NO_SRTA_E_GATOREI.DIRECCIONES D ON P.DIRECCION_ID = D.DIRECCION_ID";

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            
            SqlDataReader reader = cmd.ExecuteReader();

            IList<Proveedor> lista = new List<Proveedor>();

             while (reader.Read())
            {
                Proveedor p = new Proveedor();
                p.id = reader.GetInt16(reader.GetOrdinal("PROVEEDOR_ID"));
                p.RazonSocial = reader.GetString(reader.GetOrdinal("RAZON_SOCIAL"));
                p.cuit = reader.GetString(reader.GetOrdinal("CUIT"));
                p.mail = reader.GetString(reader.GetOrdinal("MAIL"));
                p.telefono = reader.GetString(reader.GetOrdinal("TELEFONO"));
                p.direccion = FuncionesDireccion.extractDireccion(reader);
                p.rubro = new Rubro(reader.GetInt16(reader.GetOrdinal("RUBRO_ID")), reader.GetString(reader.GetOrdinal("DESCRIPCION")));
                p.nombreContacto = reader.GetString(reader.GetOrdinal("NOMBRE_CONTACTO"));
                p.habilitado = reader.GetBoolean(reader.GetOrdinal("BAJA_LOGICA"));
                lista.Add(p);
            }
            cmd.ExecuteNonQuery();
            con.Close();

            return lista;
        }

        public static Factura facturarProveedor(int proveedorId, DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("FACTURAR_PROVEEDOR", con);
            cmd.Parameters.Add("@FECHA_DESDE",fechaDesde);
            cmd.Parameters.Add("@FECHA_HASTA",fechaHasta);
            cmd.Parameters.Add("@PROVEEDOR_ID",proveedorId);
            cmd.Parameters.Add("@FECHA_FACTURACION",new DateTime());
            cmd.Parameters.Add("@NUMERO", SqlDbType.BigInt).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Decimal).Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            Factura f = new Factura((Int64)cmd.Parameters["@NUMERO"].Value, (double)cmd.Parameters["@IMPORTE"].Value);

            con.Close();

            return f;

        }
    }


}