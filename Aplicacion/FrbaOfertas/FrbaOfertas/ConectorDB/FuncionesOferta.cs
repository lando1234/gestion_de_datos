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
    class FuncionesOferta
    {
        public static void altaOferta(Oferta oferta)
        {
            List<Rol> lista = new List<Rol>();


            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
 



            string sql = "INSERT INTO [NO_SRTA_E_GATOREI].[OFERTAS] ([PRECIO_LISTA] ,[PRECIO_OFERTA] ,[FECHA_PUBLICACION],[FECHA_VENCIMIENDO]";
          
            sql += " ,[CANTIDAD],[MAXIMO_USUARIO],[DESCRIPCION],[FECHA_COMPRA],[CODIGO],[PROVEDOR_ID])VALUES(@PRECIO_LISTA,@PRECIO_OFERTA";
            sql += ",@FECHA_PUBLICACION,@FECHA_VENCIMIENTO,@CANTIDAD,@MAXIMO_USUARIO,@DESCRIPCION,@FECHA_COMPRA,@CODIGO,@PROVEEDOR_ID)";
            

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

        public static void spOferta(Oferta oferta)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("OFERTA_SP", con);
            cmd.Parameters.AddWithValue("@CLIENTE_ID", oferta.clienteId);
            cmd.Parameters.AddWithValue("@OFERTA_ID", oferta.id);
            cmd.Parameters.AddWithValue("@FECHA_OFERTA", oferta.fecha);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
