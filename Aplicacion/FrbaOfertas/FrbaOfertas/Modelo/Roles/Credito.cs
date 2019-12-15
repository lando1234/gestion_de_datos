using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
   public class Credito : Rol
    {
        public Nullable<int> id { get; set; }
        public DateTime fecha { get; set; }
        public int tipo_pago_id { get; set; }
        public Double monto { get; set; }
        public int usuario_id { get; set; }
        public string tarjeta_nombre { get; set; }
        public Nullable<DateTime> fecha_vencimiento { get; set; }
        public String numero_tarjeta { get; set; }



        public Credito(Nullable<int> id, DateTime fecha, int tipo_pago_id, Double monto, int usuario_id, string tarjeta_nombre, Nullable<DateTime> fecha_vencimiento, String numero_tarjeta)
        {
            this.id = id;
            this.fecha = fecha;
            this.tipo_pago_id = tipo_pago_id;
            this.monto = monto;
            this.usuario_id = usuario_id;
            this.tarjeta_nombre = tarjeta_nombre;
            this.fecha_vencimiento = fecha_vencimiento;
            this.numero_tarjeta = numero_tarjeta;

                     
        }

    }
}
