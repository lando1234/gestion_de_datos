using FrbaOfertas.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.ConectorDB
{
    class FuncionesConsumoCupones
    {
        public static void consumirCupon(Cupon cupon)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CONSUMIR_CUPON", con);
            cmd.Parameters.AddWithValue("@CLIENTE_ID", cupon.clienteId);
            cmd.Parameters.AddWithValue("@PROVEEDOR_ID", cupon.proveedorId);
            cmd.Parameters.AddWithValue("@CODIGO_CUPON", cupon.codigoCupon);
            cmd.Parameters.AddWithValue("@FECHA_CUPON", cupon.fecha_cupon);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
