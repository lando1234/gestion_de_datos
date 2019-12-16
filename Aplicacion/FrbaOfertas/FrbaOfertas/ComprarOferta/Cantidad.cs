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

namespace FrbaOfertas.ComprarOferta
{
    public partial class Form1 : Form
    {
        Oferta ofertaNueva;
        public Form1(Oferta oferta)
        {
            InitializeComponent();
            ofertaNueva = oferta;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idCliente = ConectorDB.FuncionesCliente.getClienteLogueado();

            Cliente cliente = ConectorDB.FuncionesCliente.traerCliente(idCliente);
              
            ofertaNueva.cantidad = Convert.ToDecimal(cantidad.Value);
           
           
            decimal codigoCupon = ConectorDB.FuncionesOferta.comprarOferta(ofertaNueva, cliente);


            MessageBox.Show("CODIGO CUPON: ", codigoCupon.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
