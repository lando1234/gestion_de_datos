using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Modelo.Roles;
using System.Data.SqlClient;
using FrbaOfertas.BaseDeDatos;

namespace FrbaOfertas.ConectorDB
{
    public class FuncionesDireccion
    {
        public static Direccion extractDireccion(SqlDataReader reader)
        {
            return new Direccion(reader.GetInt32(reader.GetOrdinal("DIRECCION_ID")), reader.GetString(reader.GetOrdinal("CIUDAD")), reader.GetString(reader.GetOrdinal("DIRECCION")), reader.GetDecimal(reader.GetOrdinal("CODIGO_POSTAL")));
        }

        public static void actualizarDireccion(Direccion direccion)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();

            string sql = "UPDATE [NO_SRTA_E_GATOREI].[DIRECCIONES] ";
            sql += "SET [DIRECCION] = @DIRECCION ";
            sql += ",[CIUDAD] = @CIUDAD ";
            sql += ",[CODIGO_POSTAL] = @CP ";
            sql += "WHERE DIRECCION_ID = @ID ";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@DIRECCION",direccion.Calle);
            cmd.Parameters.Add("@CIUDAD",direccion.Ciudad);
            cmd.Parameters.Add("@CP",direccion.codigoPostal);
            cmd.Parameters.Add("@ID",direccion.id);

            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
