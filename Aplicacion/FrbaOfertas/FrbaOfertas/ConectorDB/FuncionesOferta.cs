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
    class FuncionesOferta
    {
        public static void altaOferta(Oferta oferta)
        {
            List<Rol> lista = new List<Rol>();


            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
 



            string sql = "INSERT INTO [NO_SRTA_E_GATOREI].[OFERTAS] ([PRECIO_LISTA] ,[PRECIO_OFERTA] ,[FECHA_PUBLICACION],[FECHA_VENCIMIENTO],[CANTIDAD],[MAXIMO_USUARIO],[DESCRIPCION],[CODIGO],[PROVEEDOR_ID])";
                   sql +=" VALUES(@PRECIO_LISTA,@PRECIO_OFERTA,@FECHA_PUBLICACION,@FECHA_VENCIMIENTO,@CANTIDAD,@MAXIMO_USUARIO,@DESCRIPCION,@CODIGO,@PROVEEDOR_ID)";
            

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@PRECIO_LISTA", oferta.precio_lista);
            cmd.Parameters.AddWithValue("@PRECIO_OFERTA", oferta.precio_oferta);
            cmd.Parameters.AddWithValue("@FECHA_PUBLICACION", oferta.fecha_publicacion);
            cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO", oferta.fecha_vencimiento);
            cmd.Parameters.AddWithValue("@CANTIDAD", oferta.cantidad);
            cmd.Parameters.AddWithValue("@MAXIMO_USUARIO", oferta.maximo_usuario);
            cmd.Parameters.AddWithValue("@DESCRIPCION", oferta.descripcion);
            cmd.Parameters.AddWithValue("@CODIGO", oferta.codigo);
            cmd.Parameters.AddWithValue("@PROVEEDOR_ID", oferta.proveedor_id);

            cmd.ExecuteNonQuery();
                        
            con.Close();
            

        }

        public static decimal comprarOferta(Oferta oferta, Cliente cliente)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("COMPRAR_OFERTA", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CLIENTE_ID", cliente.id);
            cmd.Parameters.AddWithValue("@OFERTA_ID", oferta.id);
            cmd.Parameters.AddWithValue("@FECHA_COMPRA", Config.configurationsDb.Default.fechaSistema);
            cmd.Parameters.Add("@CODIGO_CUPON", SqlDbType.Int).Direction = ParameterDirection.Output;

            var returnParameter = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();


            decimal returnValue = (int)returnParameter.Value;

            if (returnValue == 0)
            {
                returnValue = Convert.ToDecimal(cmd.Parameters["@CODIGO_CUPON"].Value);
            }

            con.Close();
            return returnValue;



          

           
        }

        public static List<Oferta> getOfertasNoVencidas()
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            string sql = "SELECT * FROM [NO_SRTA_E_GATOREI].OFERTAS WHERE @FECHA_SISTEMA < FECHA_VENCIMIENTO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@FECHA_SISTEMA", Utils.HoraSistema.get());

        
            SqlDataReader reader = cmd.ExecuteReader();

            List<Oferta> ofertas = new List<Oferta>();

          

            while (reader.Read()) {

                Oferta o = new Oferta();
                o.id = reader.GetInt32(reader.GetOrdinal("OFERTA_ID"));
                o.precio_lista= reader.GetDecimal(reader.GetOrdinal("PRECIO_LISTA"));
                o.precio_oferta = reader.GetDecimal(reader.GetOrdinal("PRECIO_OFERTA"));
                o.fecha_publicacion = reader.GetDateTime(reader.GetOrdinal("FECHA_PUBLICACION"));
                o.fecha_vencimiento = reader.GetDateTime(reader.GetOrdinal("FECHA_VENCIMIENTO"));
                o.cantidad = reader.GetDecimal(reader.GetOrdinal("CANTIDAD"));
                o.maximo_usuario = reader.GetDecimal(reader.GetOrdinal("MAXIMO_USUARIO"));
                o.descripcion = reader.GetString(reader.GetOrdinal("DESCRIPCION"));
                o.codigo = reader.GetString(reader.GetOrdinal("CODIGO"));
                o.proveedor_id = reader.GetInt32(reader.GetOrdinal("PROVEEDOR_ID"));
                ofertas.Add(o);
            }
           
            con.Close();
            return ofertas;
           
        }


    }
}
