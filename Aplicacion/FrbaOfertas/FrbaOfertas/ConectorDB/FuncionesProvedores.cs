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
using FrbaOfertas.Modelo.Roles;
using System.Security.Cryptography;
using FrbaOfertas.Utils;

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
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = ComputeSha256Hash(usuario.password);
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
        public static List<Proveedor> getProveedores()
        {
            String sql = "SELECT P.[PROVEEDOR_ID],P.[CUIT],P.[RAZON_SOCIAL],P.[NOMBRE_CONTACTO],P.[MAIL],P.[TELEFONO],P.[BAJA_LOGICA],R.*, D.* ";
            sql += "FROM NO_SRTA_E_GATOREI.PROVEEDORES P ";
            sql += "INNER JOIN NO_SRTA_E_GATOREI.RUBROS R ON P.RUBRO_ID = R.RUBRO_ID ";
            sql += "INNER JOIN NO_SRTA_E_GATOREI.DIRECCIONES D ON P.DIRECCION_ID = D.DIRECCION_ID ";

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            
            SqlDataReader reader = cmd.ExecuteReader();

            List<Proveedor> lista = new List<Proveedor>();

             while (reader.Read())
            {
                 string mailDefinido, nombreDefinido;
                 if (reader.IsDBNull(reader.GetOrdinal("MAIL"))){
                 mailDefinido = " ";
                 }else {
                     mailDefinido = reader.GetString(reader.GetOrdinal("MAIL"));
                 }

                 if (reader.IsDBNull(reader.GetOrdinal("NOMBRE_CONTACTO")))
                 {
                     nombreDefinido = " ";
                 }
                 else
                 {
                     nombreDefinido = reader.GetString(reader.GetOrdinal("NOMBRE_CONTACTO"));
                 }


                Proveedor p = new Proveedor(
                reader.GetInt32(reader.GetOrdinal("PROVEEDOR_ID")),
                reader.GetString(reader.GetOrdinal("RAZON_SOCIAL")),
                reader.GetString(reader.GetOrdinal("CUIT")),
                mailDefinido,
                reader.GetDecimal(reader.GetOrdinal("TELEFONO")),
                FuncionesDireccion.extractDireccion(reader),
                new Rubro(reader.GetInt32(reader.GetOrdinal("RUBRO_ID")), reader.GetString(reader.GetOrdinal("DESCRIPCION"))),
                nombreDefinido,
                reader.GetBoolean(reader.GetOrdinal("BAJA_LOGICA"))
                 );
                lista.Add(p);
            }
           
            con.Close();

            return lista;
        }
        public static IList<Proveedor> getProveedoresHabilitados()
        {
            String sql = "SELECT P.[PROVEEDOR_ID],P.[CUIT],P.[RAZON_SOCIAL],P.[NOMBRE_CONTACTO],P.[MAIL],P.[TELEFONO],P.[BAJA_LOGICA],R.*, D.* ";
            sql += "FROM NO_SRTA_E_GATOREI.PROVEEDORES P ";
            sql += "INNER JOIN NO_SRTA_E_GATOREI.RUBROS R ON P.RUBRO_ID = R.RUBRO_ID ";
            sql += "INNER JOIN NO_SRTA_E_GATOREI.DIRECCIONES D ON P.DIRECCION_ID = D.DIRECCION_ID ";
            sql += " WHERE P.BAJA_LOGICA = 1";
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            IList<Proveedor> lista = new List<Proveedor>();

            while (reader.Read())
            {
                Proveedor p = new Proveedor(
                reader.GetInt32(reader.GetOrdinal("PROVEEDOR_ID")),
                reader.GetString(reader.GetOrdinal("RAZON_SOCIAL")),
                reader.GetString(reader.GetOrdinal("CUIT")),
                reader.GetString(reader.GetOrdinal("MAIL")),
                reader.GetDecimal(reader.GetOrdinal("TELEFONO")),
                FuncionesDireccion.extractDireccion(reader),
                new Rubro(reader.GetInt32(reader.GetOrdinal("RUBRO_ID")), reader.GetString(reader.GetOrdinal("DESCRIPCION"))),
                reader.GetString(reader.GetOrdinal("NOMBRE_CONTACTO")),
                reader.GetBoolean(reader.GetOrdinal("BAJA_LOGICA"))
                );
                lista.Add(p);
            }
            con.Close();

            return lista;
        }

        public static Factura facturarProveedor(int proveedorId, DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("FACTURAR_PROVEEDOR", con);
            cmd.Parameters.Add("@FECHA_DESDE", fechaDesde);
            cmd.Parameters.Add("@FECHA_HASTA", fechaHasta);
            cmd.Parameters.Add("@PROVEEDOR_ID",proveedorId);
            cmd.Parameters.Add("@FECHA_FACTURACION",HoraSistema.get());
            cmd.Parameters.Add("@NUMERO", SqlDbType.BigInt).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Decimal).Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            Factura f = new Factura((Int64)cmd.Parameters["@NUMERO"].Value, (double)cmd.Parameters["@IMPORTE"].Value);

            con.Close();

            return f;

        }

        public static List<Rubro> obtenerRubros()
        {
            List<Rubro> rubros = new List<Rubro>();
            Rubro rubro1 = new Rubro(null, "Libreria");
            Rubro rubro2 = new Rubro(null, "Almacen");
            rubros.Add(rubro1);
            return rubros;
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
                return builder.ToString();
            }
        }


        internal static int getProveedorLogueado()
        {

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();




            string sql = "SELECT PROVEEDOR_ID FROM [NO_SRTA_E_GATOREI].PROVEEDORES WHERE USUARIO_ID = @USER AND BAJA_LOGICA = 1";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@USER", Session.UserSession.id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                return reader.GetInt32(0);
            }

            con.Close();
            throw new InvalidOperationException();
        }

        public static String getProveedorRazonSocial(int proveedorID) {

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();




            string sql = "SELECT RAZON_SOCIAL FROM [NO_SRTA_E_GATOREI].PROVEEDORES WHERE PROVEEDOR_ID = @ID AND BAJA_LOGICA = 0";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ID", proveedorID);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                return reader.GetString(0);
            }
            con.Close();
            throw new InvalidOperationException();
        }
    }
}