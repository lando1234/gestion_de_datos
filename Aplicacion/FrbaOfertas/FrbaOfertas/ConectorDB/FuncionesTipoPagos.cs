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
    class FuncionesTipoPagos
    {
        public static List<TipoPago> getTiposPagos()
        {

            List<TipoPago> tiposPagos = new List<TipoPago>();


            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();




            string sql = "SELECT * FROM [NO_SRTA_E_GATOREI].TIPOS_PAGOS WHERE DESCRIPCION NOT LIKE 'REGALO'";


            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                tiposPagos.Add(new TipoPago(reader.GetInt32(reader.GetOrdinal("TIPO_PAGO_ID")), reader.GetString(reader.GetOrdinal("DESCRIPCION"))));
            }

            return tiposPagos;

        }
    }
}
