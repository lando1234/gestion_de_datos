using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    public class Oferta : Rol
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public decimal precio_oferta { get; set; }
        public decimal precio_lista { get; set; }
        public decimal cantidad { get; set; }
        public decimal maximo_usuario { get; set; }
        public string codigo { get; set; }
        public int entregado { get; set; }
        public int proveedor_id { get; set; }



        public Oferta() { }

        public Oferta(int id, string descripcion, DateTime fecha_publicacion, DateTime fecha_vencimiento, decimal precio_oferta, decimal precio_lista, decimal cantidad, decimal maximo_usuario,
            string codigo, int entregado, int proveedor_id)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fecha_publicacion = fecha_publicacion;
            this.fecha_vencimiento = fecha_vencimiento;
            this.precio_oferta = precio_oferta;
            this.precio_lista = precio_lista;
            this.cantidad = cantidad;
            this.maximo_usuario = maximo_usuario;
            this.codigo = codigo;
            this.proveedor_id = proveedor_id;

        }
    }
}
