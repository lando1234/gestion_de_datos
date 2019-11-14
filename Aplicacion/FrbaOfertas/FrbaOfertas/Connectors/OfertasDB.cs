using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using FrbaOfertas.Excepciones;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FrbaOfertas
{
    public sealed class OfertasDB
    {
        private static readonly OfertasDB instance = new OfertasDB();
        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2C2019"].ConnectionString);
        private readonly DateTime fechaSistema = Convert.ToDateTime(ConfigurationManager.AppSettings["DefaultDate"]);
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static OfertasDB()
        {
        }

        private OfertasDB()
        {
        }

        public static OfertasDB Instance
        {
            get
            {
                return instance;
            }
        }

        public SqlConnection GetDBConnection()
        {
            return con;
        }

        public DateTime getFechaSistema()
        {
            return this.fechaSistema;
        }


        internal int login(string username, string password)
        {

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("Login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;


                    con.Open();
                    cmd.ExecuteNonQuery();

                    int result = (int)returnParameter.Value;

                    return result;
                }
            }

        }

        internal void crearUsuarioCliente(String username, String password, String rol, String nombre, String apellido, String dni, String mail, String telefono, String direccion, String cp, String ciudad, String fecha)
        { }
    }
}

