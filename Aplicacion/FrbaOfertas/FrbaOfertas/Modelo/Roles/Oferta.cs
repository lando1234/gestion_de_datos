using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    class Oferta : Rol
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public float precio_oferta { get; set; }
        public float precio_lista { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha_compra { get; set; }
        public int codigo { get; set; }
        public int entregado { get; set; }
        public int proveedor_id { get; set; }



        public Oferta(int id, string descripcion, DateTime fecha_publicacion, DateTime fecha_vencimiento, float precio_oferta, float precio_lista, int cantidad,
            DateTime fecha_compra, int codigo, int entregado, int proveedor_id)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fecha_publicacion = fecha_publicacion;
            this.fecha_vencimiento = fecha_vencimiento;
            this.precio_oferta = precio_oferta;
            this.precio_lista = precio_lista;
            this.cantidad = cantidad;
            this.fecha_compra = fecha_compra;
            this.codigo = codigo;
            this.entregado = entregado;
            this.proveedor_id = proveedor_id;

        }
    }
}
