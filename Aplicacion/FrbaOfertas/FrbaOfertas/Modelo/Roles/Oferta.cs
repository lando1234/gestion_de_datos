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
        public int maximo_usuario { get; set; }
        public DateTime fecha_compra { get; set; }
        public string codigo { get; set; }
        public int entregado { get; set; }
        public int proveedor_id { get; set; }



        public Oferta() { }

        public Oferta(int id, string descripcion, DateTime fecha_publicacion, DateTime fecha_vencimiento, float precio_oferta, float precio_lista, int cantidad, int maximo_usuario,
            DateTime fecha_compra, string codigo, int entregado, int proveedor_id)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fecha_publicacion = fecha_publicacion;
            this.fecha_vencimiento = fecha_vencimiento;
            this.precio_oferta = precio_oferta;
            this.precio_lista = precio_lista;
            this.cantidad = cantidad;
            this.maximo_usuario = maximo_usuario;
            this.fecha_compra = fecha_compra;
            this.codigo = codigo;
            this.entregado = entregado;
            this.proveedor_id = proveedor_id;

        }
    }
}
