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

            con.Open();
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

            return result;

        }
           
        }
        public static Cliente traerCliente(int id)
        {
            return null;
        }


        public static Boolean existeDNI(string dni)
        {
            return false;

        }

        public static Boolean existeMail(string mail)
        {
            return false;

        }
        public static void BajaLogicaCliente(int id)
        {

            
        }
        public static void UpdateCliente(Cliente cliente)
        {

           
        }

    }
}
