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
    public partial class RecargarCredito : Form
    {
        public RecargarCredito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Double cantidad = Convert.ToDouble(cantidadACargar.Value);
            TipoPago tipopago = (TipoPago) tipoPago.SelectedItem;

            if (tipoPago.Text == "Credito") {
                Form alta = new CargaDeCredito.CargaTarjeta(tipopago.id, cantidad);
                alta.Show();
            }
            if (tipoPago.Text == "Efectivo")
            {
                Credito credito = new Credito(null,
                    HoraSistema.get(), tipopago.id, cantidad, Session.UserSession.id,
                    null, null, null);

                ConectorDB.FuncionesCargaCredito.cargaCredito(credito);
            }
        }

        private void RecargarCredito_Load(object sender, EventArgs e)
        {
            List<TipoPago> tiposDePago = ConectorDB.FuncionesTipoPagos.getTiposPagos();
            foreach (TipoPago tipo in tiposDePago)
            {
                tipoPago.Items.Add(tipo);
            }
        }
    }
}
