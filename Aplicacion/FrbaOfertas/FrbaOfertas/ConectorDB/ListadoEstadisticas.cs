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
            string sql = "select top 5 p.RAZON_SOCIAL,sum(o.PRECIO_OFERTA)/sum(o.PRECIO_LISTA*o.CANTIDAD) * 100 as porcentaje ";
            sql += "from NO_SRTA_E_GATOREI.PROVEEDORES p ";
            sql = "inner join NO_SRTA_E_GATOREI.OFERTAS o ";
            sql = "on p.PROVEEDOR_ID = o.PROVEDOR_ID ";
            sql = "where FECHA_PUBLICACION between @FROM and @TO";
            sql = "group by p.RAZON_SOCIAL ";
            sql = "order by 2 desc; ";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@FROM", desde);
            cmd.Parameters.Add("@TO", hasta);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.NextResult())
            {
                ProveedorValor p = new ProveedorValor();
                p.razonSocial = r.GetString(1);
                p.monto = r.GetDouble(2);
                lista.Add(p);
            }

            return lista;

        }
        public static IList<ProveedorValor> getMasFacturacion(DateTime desde, DateTime hasta)
        {
            IList<ProveedorValor> lista = new List<ProveedorValor>();

            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();

            string sql = "select top 5 p.RAZON_SOCIAL, sum(f.importe) ";
            sql = "from NO_SRTA_E_GATOREI.PROVEEDORES p ";
            sql = "inner join NO_SRTA_E_GATOREI.OFERTAS o ";
            sql = "on p.PROVEEDOR_ID = o.PROVEDOR_ID ";
            sql = "inner join NO_SRTA_E_GATOREI.COMPRAS c ";
            sql = "on o.OFERTA_ID = c.OFERTA_ID ";
            sql = "inner join NO_SRTA_E_GATOREI.FACTURAS_COMPRAS fc ";
            sql = "on c.COMPRA_ID = fc.COMPRA_ID ";
            sql = "inner join NO_SRTA_E_GATOREI.FACTURAS f ";
            sql = "on fc.FACTURA_ID = f.FACTURA_ID ";
            sql = "where f.FACTURA_ID is not null ";
            sql = "and FECHA_PUBLICACION between @FROM and @TO";
            sql = "group by p.RAZON_SOCIAL ";
            sql = "order by 2 desc ";

            
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@FROM", desde);
            cmd.Parameters.Add("@TO", hasta);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.NextResult())
            {
                ProveedorValor p = new ProveedorValor();
                p.razonSocial = r.GetString(1);
                p.monto = r.GetDouble(2);
                lista.Add(p);
            }

            return lista;

        }

    }
}
