using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    public class Cupon
    {
        int id;
        int clienteId;
        DateTime fechaConsumo;

        public Cupon(int id, int clienteId, DateTime fechaConsumo) {
            this.id = id;
            this.clienteId = clienteId;
            this.fechaConsumo = fechaConsumo;
        } 
    }
}
