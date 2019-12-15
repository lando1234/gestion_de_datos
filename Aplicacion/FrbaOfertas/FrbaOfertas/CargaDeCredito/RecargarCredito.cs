using FrbaOfertas.Modelo.Roles;
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
    public partial class RecargarCredito : Form
    {
        public RecargarCredito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Double cantidad = Convert.ToDouble(cantidadACargar.Value);

            if (tipoPago.Text == "Credito") {
                Form alta = new CargaDeCredito.CargaTarjeta();
                alta.Show();
            }
            if (tipoPago.Text == "Efectivo")
            {
                //Credito credito = new Credito(null, FrbaOfertas.Config.configurationsDb.Default.fechaSistema,tipoPago.SelectedItem
                //ConectorDB.FuncionesCargaCredito.cargaCredito()
            }
        }
    }
}
