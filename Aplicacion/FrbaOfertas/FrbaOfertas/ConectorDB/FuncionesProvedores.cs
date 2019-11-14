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


            con.Open();
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

            return result;

        }
            
        }

        public static void crearRubro(string Rubro)
        {


        }

        public static Boolean existeRubro(string rubro)
        {
           return false;
        }


    }
}
