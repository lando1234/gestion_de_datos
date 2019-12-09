using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
   public class Credito : Rol
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int tipo_pago_id { get; set; }
        public float monto { get; set; }
        public int cliente_id { get; set; }
        public int tarjeta_id { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public int numero_tarjeta { get; set; }

   

        public Credito(int id, DateTime fecha, int tipo_pago_id, float monto, int cliente_id, int tarjeta_id, DateTime fecha_vencimiento,int numero_tarjeta )
        {
            this.id = id;
            this.fecha = fecha;
            this.tipo_pago_id = tipo_pago_id;
            this.monto = monto;
            this.cliente_id = cliente_id;
            this.tarjeta_id = tarjeta_id;
            this.fecha_vencimiento = fecha_vencimiento;
            this.numero_tarjeta = numero_tarjeta;

                     
        }

    }
}
