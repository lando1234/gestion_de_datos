using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Modelo;
using System.Data.SqlClient;
using FrbaOfertas.BaseDeDatos;


namespace FrbaOfertas.ConectorDB
{

    public class ListadoEstadisticas
    {
        public static IList<ProveedorValor> getMasPorcentaje(DateTime desde, DateTime hasta)
        {
            IList<ProveedorValor> lista = new List<ProveedorValor>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            string sql = "select top 5 p.RAZON_SOCIAL,count(o.oferta_id) as ofertas,sum(o.PRECIO_OFERTA)/sum(o.PRECIO_LISTA) * 100 as porcentaje ";
            sql += "from NO_SRTA_E_GATOREI.PROVEEDORES p ";
            sql += "inner join NO_SRTA_E_GATOREI.OFERTAS o ";
            sql += "on p.PROVEEDOR_ID = o.PROVEEDOR_ID ";
            sql += "where FECHA_PUBLICACION between convert(datetime,@FROM,121) and convert(datetime,@TO,121)";
            sql += "group by p.RAZON_SOCIAL ";
            sql += "order by 2 desc; ";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@FROM", desde);
            cmd.Parameters.Add("@TO", hasta);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                ProveedorValor p = new ProveedorValor();
                p.razonSocial = r.GetString(0);
                p.cantidad = r.GetInt32(1);
                p.monto = r.GetDecimal(2);
                lista.Add(p);
            }

            return lista;

        }
        public static IList<ProveedorValor> getMasFacturacion(DateTime desde, DateTime hasta)
        {
            IList<ProveedorValor> lista = new List<ProveedorValor>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();

            string sql = "select top 5 p.RAZON_SOCIAL,count(distinct f.factura_id), sum(f.importe) ";
            sql += "from NO_SRTA_E_GATOREI.PROVEEDORES p ";
            sql += "inner join NO_SRTA_E_GATOREI.OFERTAS o ";
            sql += "on p.PROVEEDOR_ID = o.PROVEEDOR_ID ";
            sql += "inner join NO_SRTA_E_GATOREI.COMPRAS c ";
            sql += "on o.OFERTA_ID = c.OFERTA_ID ";
            sql += "inner join NO_SRTA_E_GATOREI.FACTURAS_COMPRAS fc ";
            sql += "on c.COMPRA_ID = fc.COMPRA_ID ";
            sql += "inner join NO_SRTA_E_GATOREI.FACTURAS f ";
            sql += "on fc.FACTURA_ID = f.FACTURA_ID ";
            sql += "where f.FACTURA_ID is not null ";
            sql += "and FECHA between convert(datetime,@FROM,121) and convert(datetime,@TO,121) ";
            sql += "group by p.RAZON_SOCIAL ";
            sql += "order by 2 desc ";

            
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@FROM", desde);
            cmd.Parameters.AddWithValue("@TO", hasta);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                ProveedorValor p = new ProveedorValor();
                p.razonSocial = r.GetString(0);
                p.monto = r.GetDecimal(2);
                p.cantidad = r.GetInt32(1);
                lista.Add(p);
            }

            return lista;

        }


        internal static IEnumerable<int> getAniosFacturas()
        {
            List<int> lista = new List<int>();
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT YEAR(FECHA) FROM NO_SRTA_E_GATOREI.FACTURAS", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                lista.Add(reader.GetInt32(0));
            }

            return lista;
        }
    }
}
