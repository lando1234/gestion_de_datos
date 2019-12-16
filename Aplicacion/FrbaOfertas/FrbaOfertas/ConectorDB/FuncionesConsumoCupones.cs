using FrbaOfertas.BaseDeDatos;
using FrbaOfertas.Modelo.Roles;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static int consumirCupon(Cupon cupon, int proveedorId){

           

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CONSUMIR_CUPON", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PROVEEDOR_ID", proveedorId);
            cmd.Parameters.AddWithValue("@FECHA_CONSUMO", cupon.fechaConsumo);
            cmd.Parameters.AddWithValue("@CODIGO_CUPON",cupon.id);
            
            var returnParameter = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();


            int returnValue = (int)returnParameter.Value;

            
            con.Close();
            return returnValue;
        

            
            
        }


    /*        -1 distinto al que genero el cupon
                -2 ya fue entregado
                    3 estavencido
  */      
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
