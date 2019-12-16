using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Modelo.Roles;
using System.Data;
using FrbaOfertas.BaseDeDatos;
using System.Data.SqlClient;
using System.Security.Cryptography;
using FrbaOfertas.Modelo;

namespace FrbaOfertas.ConectorDB
{
    class FuncionesCliente
    {
        
         public static int altaCliente(Cliente cliente, Usuario usuario)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CREAR_USUARIO_CLIENTE", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = usuario.username;
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = ComputeSha256Hash(usuario.password);
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = cliente.nombre;
            cmd.Parameters.Add("@APELLIDO", SqlDbType.VarChar).Value = cliente.apellido;
            cmd.Parameters.Add("@DNI", SqlDbType.Int).Value = cliente.dni;
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = cliente.mail;
            cmd.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = cliente.telefono;
            cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = cliente.direccion.Calle;
            cmd.Parameters.Add("@CP", SqlDbType.Int).Value = cliente.direccion.codigoPostal;
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = cliente.direccion.Ciudad;
            cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.DateTime).Value = cliente.fecha_nacimiento;
            cmd.Parameters.Add("@FECHA_ACTUAL", SqlDbType.DateTime).Value = DateTime.Now;

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

           
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;


            con.Close();
            return result;

        }

         public static int crearCliente(Cliente cliente)
         {
             SqlConnection con = new SqlConnection(Conexion.getStringConnection());
             con.Open();
             SqlCommand cmd = new SqlCommand("CREAR_CLIENTE", con);

             cmd.CommandType = CommandType.StoredProcedure;

            
             cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = cliente.nombre;
             cmd.Parameters.Add("@APELLIDO", SqlDbType.VarChar).Value = cliente.apellido;
             cmd.Parameters.Add("@DNI", SqlDbType.Int).Value = cliente.dni;
             cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = cliente.mail;
             cmd.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = cliente.telefono;
             cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = cliente.direccion.Calle;
             cmd.Parameters.Add("@CP", SqlDbType.Int).Value = cliente.direccion.codigoPostal;
             cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = cliente.direccion.Ciudad;
             cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.DateTime).Value = cliente.fecha_nacimiento;
             cmd.Parameters.Add("@FECHA_ACTUAL", SqlDbType.DateTime).Value = DateTime.Now;

             var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
             returnParameter.Direction = ParameterDirection.ReturnValue;


             cmd.ExecuteNonQuery();

             int result = (int)returnParameter.Value;


             con.Close();
             return result;
         }

         public List<Cliente> buscar(string nombre, string apellido, string dni, string mail)
         {
             String sql = "SELECT * FROM [NO_SRTA_E_GATOREI].CLIENTES c INNER JOIN [NO_SRTA_E_GATOREI].DIRECCIONES d ON c.DIRECCION_ID = d.DIRECCION_ID ";
                 sql += "WHERE 1 = 1 ";
                 if (nombre != null && nombre.Trim() != "")
                 {
                     sql += "AND NOMBRE LIKE '%" + nombre + "% ";
                 }
                 if (apellido != null && apellido.Trim() != "")
                 {
                     sql += "AND APELLIDO LIKE '%" + apellido + "% ";
                 }
                 if (dni != null && dni.Trim() != "")
                 {
                     sql += "AND DNI = '" + dni +"'" ;
                 }
                 if (mail != null && mail.Trim() != "")
                 {
                     sql += "AND MAIL LIKE '%" + mail + "% ";
                 }

                 return getClientes(sql);
         }

         public static List<Cliente> getClientes() 
         {
             return getClientes("SELECT * FROM [NO_SRTA_E_GATOREI].CLIENTES c INNER JOIN [NO_SRTA_E_GATOREI].DIRECCIONES d ON c.DIRECCION_ID = d.DIRECCION_ID ");
         }
         public static List<Cliente> getClientes(string sql)
         {

             List<Cliente> clientes = new List<Cliente>();


             SqlConnection con = new SqlConnection(Conexion.getStringConnection());
             con.Open();

             SqlCommand cmd = new SqlCommand(sql, con);

             SqlDataReader registros = cmd.ExecuteReader();

             while (registros.Read())
             {
                 Nullable <int> usuarioId;
            
                 if(registros.IsDBNull(registros.GetOrdinal("USUARIO_ID"))){
                 usuarioId = null;
                 }else{
                 usuarioId = registros.GetInt32(registros.GetOrdinal("USUARIO_ID"));
                 }

                 clientes.Add(new Cliente(registros.GetInt32(registros.GetOrdinal("CLIENTE_ID")),
                  registros.GetDecimal(registros.GetOrdinal("DNI")),
                  registros.GetString(registros.GetOrdinal("NOMBRE")),
                  registros.GetString(registros.GetOrdinal("APELLIDO")),
                  registros.GetString(registros.GetOrdinal("MAIL")),
                  registros.GetDecimal(registros.GetOrdinal("TELEFONO")),
                  registros.GetDateTime(registros.GetOrdinal("FECHA_NACIMIENTO")),
                  registros.GetBoolean(registros.GetOrdinal("BAJA_LOGICA")),
                  usuarioId,
                  FuncionesDireccion.extractDireccion(registros)
                 ));
             }
             con.Close();
             return clientes;

         }

         public static int cargarCreditoCliente(int clienteID, String tipoPago, Decimal monto, String nombre, String fechaVencimiento, String numero)
         {
             SqlConnection con = new SqlConnection(Conexion.getStringConnection());
             con.Open();
             SqlCommand cmd = new SqlCommand("CARGAR_CREDITO", con);

             cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.Add("@FECHA", SqlDbType.VarChar).Value = DateTime.Now; ;
             cmd.Parameters.Add("@CLIENTE_ID", SqlDbType.VarChar).Value = clienteID;
             cmd.Parameters.Add("@TIPO_PAGO", SqlDbType.VarChar).Value = tipoPago;
             cmd.Parameters.Add("@MONTO", SqlDbType.VarChar).Value = monto;
             cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = nombre;
             cmd.Parameters.Add("@FECHA_VENCIMIENTO", SqlDbType.VarChar).Value = fechaVencimiento;
             cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = numero;

             
             cmd.ExecuteNonQuery();
             con.Close();
             //VER RETORNO SIN PARAMETRO DE SALIDA
             return 1;
         }
        
        public static Cliente traerCliente(int clienteId)
        {
           Cliente cliente = null;
           Nullable <int> usuarioId = null;

           SqlConnection con = new SqlConnection(Conexion.getStringConnection());
           con.Open();
           String sql = "SELECT * FROM [NO_SRTA_E_GATOREI].CLIENTES c INNER JOIN [NO_SRTA_E_GATOREI].DIRECCIONES d ON d.DIRECCION_ID = c.DIRECCION_ID  WHERE CLIENTE_ID = @CLIENTE_ID";
           SqlCommand cmd = new SqlCommand(sql, con);

           cmd.Parameters.Add(new SqlParameter("@CLIENTE_ID", clienteId));

           SqlDataReader registros = cmd.ExecuteReader();

          

           while (registros.Read())
           {
               if (registros.IsDBNull(registros.GetOrdinal("USUARIO_ID")))
               {
                   usuarioId = null;
               }
               else
               {
                   usuarioId = registros.GetInt32(registros.GetOrdinal("USUARIO_ID"));
               }


               

               cliente = new Cliente(clienteId,
                  registros.GetDecimal(registros.GetOrdinal("DNI")),
                  registros.GetString(registros.GetOrdinal("NOMBRE")),
                  registros.GetString(registros.GetOrdinal("APELLIDO")),
                  registros.GetString(registros.GetOrdinal("MAIL")),
                  registros.GetDecimal(registros.GetOrdinal("TELEFONO")),
                  registros.GetDateTime(registros.GetOrdinal("FECHA_NACIMIENTO")),
                  registros.GetBoolean(registros.GetOrdinal("BAJA_LOGICA")),
                  usuarioId,
                  FuncionesDireccion.extractDireccion(registros)
                 );
           }
           return cliente;
        }


        public static Boolean existeDNI(string dni)
        {
           
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            String sql = "SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].CLIENTES WHERE DNI = @DNI ";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add(new SqlParameter("@DNI", dni));

            SqlDataReader registros = cmd.ExecuteReader();

            return registros.HasRows;

        }

        public static Boolean existeMail(string mail)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            String sql = "SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].CLIENTES WHERE MAIL = @MAIL ";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add(new SqlParameter("@MAIL", mail));

            SqlDataReader registros = cmd.ExecuteReader();

            return registros.HasRows;

        }
        public static void BajaLogicaCliente(int clienteID)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            String sql = "UPDATE CLIENTES SET BAJA_LOGICA = 1 WHERE CLIENTE_ID = @CLIENTE_ID";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@CLIENTE_ID", clienteID));

            cmd.ExecuteNonQuery();

        }
        public static void invertirBajaLogicaCliente(int clienteID)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("INVERTIR_BAJA_LOGICA_CLIENTE", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CLIENTE_ID", SqlDbType.VarChar).Value = clienteID;
            
           
            cmd.ExecuteNonQuery();
        }
        public static void UpdateCliente(Cliente cliente)
        {

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();

            string sql = "UPDATE [NO_SRTA_E_GATOREI].[CLIENTES] ";
            sql += "SET [DNI] = @DNI ";
            sql += ",[NOMBRE] = @NOMBRE ";
            sql += ",[APELLIDO] = @APELLIDO ";
            sql += ",[FECHA_NACIMIENTO] = @FECHA_NACIMIENTO ";
            sql += ",[USUARIO_ID] = @USUARIO_ID ";
            sql += ",[DIRECCION_ID] = @DIRECCION_ID ";
            sql += ",[MAIL] = @MAIL ";
            sql += ",[TELEFONO] = @TELEFONO ";
            sql += ",[BAJA_LOGICO] = @BAJA_LOGICO ";
            sql += "WHERE CLIENTE_ID = @ID ";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@DNI", cliente.dni);
            cmd.Parameters.Add("@NOMBRE", cliente.nombre);
            cmd.Parameters.Add("@APELLIDO", cliente.apellido);
            cmd.Parameters.Add("@FECHA_NACIMIENTO", cliente.fecha_nacimiento);
            cmd.Parameters.Add("@USUARIO_ID", cliente.usuarioId);
            cmd.Parameters.Add("@DIRECCION_ID", cliente.direccion);
            cmd.Parameters.Add("@MAIL", cliente.mail);
            cmd.Parameters.Add("@TELEFONO", cliente.telefono);
            cmd.Parameters.Add("@BAJA_LOGICO", cliente.habilitado);
            cmd.Parameters.Add("@ID", cliente.id);
           


            cmd.ExecuteNonQuery();
            con.Close(); 
        }

        internal static int getClienteLogueado()
        {

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();




            string sql = "SELECT CLIENTE_ID FROM [NO_SRTA_E_GATOREI].CLIENTES WHERE USUARIO_ID = @USER AND BAJA_LOGICA = 1";

            SqlCommand cmd = new SqlCommand(sql, con);

           
            cmd.Parameters.AddWithValue("@USER",  Session.UserSession.id);

            SqlDataReader reader = cmd.ExecuteReader();

           while(reader.Read())
            {

                return reader.GetInt32(0);
            }

            con.Close();
            throw new InvalidOperationException();
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

    }
}
