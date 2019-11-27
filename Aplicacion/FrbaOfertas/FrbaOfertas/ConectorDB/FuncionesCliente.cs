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
    class FuncionesCliente
    {
        
         public static int altaCliente(Cliente cliente, String username, String password, String rol, Decimal cp)
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
            cmd.Parameters.Add("@DNI", SqlDbType.VarChar).Value = cliente.documento;
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = cliente.mail;
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = cliente.telefono;
            cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = cliente.Calle;
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = cp;
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = cliente.Localidad;
            cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.VarChar).Value = cliente.fecha_nacimiento;
            cmd.Parameters.Add("@FECHA_ACTUAL", SqlDbType.VarChar).Value = DateTime.Now;

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

           
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

            return result;

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
        
        public static Cliente traerCliente(int id)
        {
            return null;
        }


        public static Boolean existeDNI(string dni)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].CLIENTES WHERE DNI ='" + dni + "'", con);


            /*
            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;*/

            SqlDataReader registros = cmd.ExecuteReader();

            return registros.HasRows;

        }

        public static Boolean existeMail(string mail)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT USUARIO_ID FROM [NO_SRTA_E_GATOREI].CLIENTES WHERE MAIL ='" + mail + "'", con);


            /*
            var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;*/

            SqlDataReader registros = cmd.ExecuteReader();

            return registros.HasRows;

        }
        public static void BajaLogicaCliente(int clienteID)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE CLIENTES SET BAJA_LOGICA = 1 WHERE CLIENTE_ID ='" + clienteID + "'", con);
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

           
        }

    }
}
