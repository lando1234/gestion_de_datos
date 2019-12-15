using FrbaOfertas.Modelo.Roles;
using FrbaOfertas.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CargaDeCredito
{
    public partial class CargaTarjeta : Form
    {
        private int tipopago;
        private double cantidad;

        public CargaTarjeta()
        {
            InitializeComponent();
        }

        public CargaTarjeta(int p, double cantidad)
        {
            InitializeComponent();
            this.tipopago = p;
            this.cantidad = cantidad;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Credito credito = new Credito(null,
                    HoraSistema.get(), tipopago, cantidad, Session.UserSession.id,
                    nombreTitular.Text, fechaVencimiento.Value, numeroTarjeta.Value.ToString());

            ConectorDB.FuncionesCargaCredito.cargaCredito(credito);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
