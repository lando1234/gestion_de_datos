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
            try
            {

                this.validar();

                Double cantidad = Convert.ToDouble(cantidadACargar.Value);
                TipoPago tipopago = (TipoPago)tipoPago.SelectedItem;


                if (tipopago.descripcion.ToLower().Equals("crédito"))
                {
                    Form alta = new CargaDeCredito.CargaTarjeta(tipopago.id, cantidad);
                    alta.Show();
                }
                if (tipopago.descripcion.ToLower().Equals("efectivo"))
                {
                    Credito credito = new Credito(null,
                        HoraSistema.get(), tipopago.id, cantidad, Session.UserSession.id,
                        "", HoraSistema.get(), "");

                    ConectorDB.FuncionesCargaCredito.cargaCredito(credito);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validar()
        {
            if (cantidadACargar.Value == null || cantidadACargar.Value == 0)
            {
                throw new ArgumentException("Debe ingresar un crédito", "original");
            }
            if (tipoPago.SelectedItem == null)
            {
                throw new ArgumentException("Debe seleccionar un tipo de pago", "original");
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
