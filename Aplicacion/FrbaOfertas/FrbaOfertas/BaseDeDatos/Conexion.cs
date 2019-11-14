using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaOfertas.BaseDeDatos
{
    class Conexion
    {
        public static string getStringConnection()
        {
            return Config.configurationsDb.Default.connectionString;
        }

        private static SqlConnection create()
        {
            return new SqlConnection(getStringConnection());
        }

        private static SqlConnection open(SqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return conn;
        }

        public static void close(SqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static SqlConnection getConnection()
        {
            return open(create());
        }
    }
}
