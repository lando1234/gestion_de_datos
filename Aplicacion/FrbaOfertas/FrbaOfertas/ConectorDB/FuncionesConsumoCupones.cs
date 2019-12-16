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
    class FuncionesConsumoCupones
    {

        public static List<Cupon> obtenerCuponPorIdNoVencido(int idCliente) {
            List<Cupon> cupones = new List<Cupon>();

        
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            string sql = "SELECT * FROM [NO_SRTA_E_GATOREI].CUPONES WHERE CLIENTE_ID = @ID_CLIENTE AND  @FECHA_SISTEMA < FECHA_CONSUMO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@FECHA_SISTEMA", Utils.HoraSistema.get());
            cmd.Parameters.AddWithValue("@ID_CLIENTE", idCliente);

        
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {

                Cupon c = new Cupon(
                    reader.GetInt32(reader.GetOrdinal("CUPON_ID")),
                    reader.GetInt32(reader.GetOrdinal("CLIENTE_ID")),
                    reader.GetDateTime(reader.GetOrdinal("FECHA_CONSUMO"))
                );
                cupones.Add(c);
            }
           
            con.Close();
           
           
        
            return cupones;
        
        }
        
        //public static void consumirCupon(Cupon cupon)
        //{
        //    SqlConnection con = new SqlConnection(Conexion.getStringConnection());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("CONSUMIR_CUPON", con);
        //    cmd.Parameters.AddWithValue("@CLIENTE_ID", cupon.clienteId);
        //    cmd.Parameters.AddWithValue("@PROVEEDOR_ID", cupon.proveedorId);
        //    cmd.Parameters.AddWithValue("@CODIGO_CUPON", cupon.codigoCupon);
        //    cmd.Parameters.AddWithValue("@FECHA_CUPON", cupon.fecha_cupon);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
    }
}
