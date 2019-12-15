using FrbaOfertas.BaseDeDatos;
using FrbaOfertas.Modelo.Roles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.ConectorDB
{
    class FuncionesRubro
    {
        public static List<Rubro> getRubros() {

            List <Rubro> rubros = new List<Rubro>();

            
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();




            string sql = "SELECT * FROM [NO_SRTA_E_GATOREI].RUBROS";
            

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) { 
            
               rubros.Add(new Rubro(reader.GetInt32(reader.GetOrdinal("id")) , reader.GetString(reader.GetOrdinal("descripcion"))));
            }

            con.Close();

            return rubros;
        
        }
    }
}
