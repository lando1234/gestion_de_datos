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

namespace FrbaOfertas.ConectorDB
{
    class FuncionesCliente
    {
        
         public static int altaCliente(Cliente cliente, String username, String password, String rol, Decimal cp, String ciudad)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CREAR_USUARIO_CLIENTE", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@ROL", SqlDbType.VarChar).Value = rol;
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = cliente.nombre;
            cmd.Parameters.Add("@APELLIDO", SqlDbType.VarChar).Value = cliente.apellido;
            cmd.Parameters.Add("@DNI", SqlDbType.VarChar).Value = cliente.dni;
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = cliente.mail;
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = cliente.telefono;
            cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = cliente.direccionId;
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = cp;
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = ciudad;
            cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.VarChar).Value = cliente.fecha_nacimiento;
            cmd.Parameters.Add("@FECHA_ACTUAL", SqlDbType.VarChar).Value = DateTime.Now;

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

           
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

            return result;

        }

         public static List<Cliente> getClientes()
         {

             List<Cliente> clientes = new List<Cliente>();


             SqlConnection con = new SqlConnection(Conexion.getStringConnection());
             con.Open();




             string sql = "SELECT * FROM [NO_SRTA_E_GATOREI].CLIENTES";


             SqlCommand cmd = new SqlCommand(sql, con);

             SqlDataReader registros = cmd.ExecuteReader();

             while (registros.Read())
             {

                  

                 clientes.Add(new Cliente(registros.GetInt32(registros.GetOrdinal("CLIENTE_ID")),
                  registros.GetInt16(registros.GetOrdinal("DNI")),
                  registros["NOMBRE"].ToString(),
                  registros["APELLIDO"].ToString(),
                  registros["MAIL"].ToString(),
                  registros.GetInt16(registros.GetOrdinal("TELEFONO")),
                  registros["FECHA_NACIMIENTO"].ToString(),
                  registros.GetBoolean(registros.GetOrdinal("BAJA_LOGICA")),
                  registros.GetInt16(registros.GetOrdinal("USUARIO_ID")),
                  registros.GetInt16(registros.GetOrdinal("DIRECCION_ID"))));
             }

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
             
             //VER RETORNO SIN PARAMETRO DE SALIDA
             return 1;
         }
        
        public static Cliente traerCliente(int clienteId)
        {
           Cliente cliente = null;

           SqlConnection con = new SqlConnection(Conexion.getStringConnection());
           con.Open();
           String sql = "SELECT * FROM [NO_SRTA_E_GATOREI].CLIENTES WHERE CLIENTE_ID = @CLIENTE_ID ";
           SqlCommand cmd = new SqlCommand(sql, con);

           cmd.Parameters.Add(new SqlParameter("@CLIENTE_ID", clienteId));

           SqlDataReader registros = cmd.ExecuteReader();

           if (registros.Read())
           {
               cliente = new Cliente(clienteId,
                   registros.GetInt16(registros.GetOrdinal("DNI")),
                   registros["NOMBRE"].ToString(),
                   registros["APELLIDO"].ToString(),
                   registros["MAIL"].ToString(),
                   registros.GetInt16(registros.GetOrdinal("TELEFONO")),
                   registros["FECHA_NACIMIENTO"].ToString(),
                   registros.GetBoolean(registros.GetOrdinal("BAJA_LOGICA")),
                   registros.GetInt16(registros.GetOrdinal("USUARIO_ID")),
                   registros.GetInt16(registros.GetOrdinal("DIRECCION_ID")));
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
            cmd.Parameters.Add("@DIRECCION_ID", cliente.direccionId);
            cmd.Parameters.Add("@MAIL", cliente.mail);
            cmd.Parameters.Add("@TELEFONO", cliente.telefono);
            cmd.Parameters.Add("@BAJA_LOGICO", cliente.habilitado);
            cmd.Parameters.Add("@ID", cliente.id);
           


            cmd.ExecuteNonQuery();
            con.Close(); 
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
