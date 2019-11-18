using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.BaseDeDatos;
using System.Data.SqlClient;
using System.Data;


namespace FrbaOfertas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new LoginForm());

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            SqlCommand cmd = new SqlCommand("CREAR_USUARIO_CLIENTE", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = "elena@gmail.com";
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = "pass";
            cmd.Parameters.Add("@ROL", SqlDbType.VarChar).Value = "1";
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = "ELENA";
            cmd.Parameters.Add("@APELLIDO", SqlDbType.VarChar).Value = "Zuñiga";
            cmd.Parameters.Add("@DNI", SqlDbType.VarChar).Value = "15338003";
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = "elena@gmail.com";
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = "5239622";
            cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = null;
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = "1464";
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = "localidad";
            cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.VarChar).Value = "fecha";
            cmd.Parameters.Add("@FECHA_ACTUAL", SqlDbType.VarChar).Value = DateTime.Now;

            var returnParameter = cmd.Parameters.Add("@RESULT", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            con.Open();
            cmd.ExecuteNonQuery();

            int result = (int)returnParameter.Value;

           


        }
    }
}
