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
using FrbaOfertas.ConectorDB;

namespace FrbaOfertas.ComprarOferta
{
    public partial class CompraDeOferta : Form
    {

        List<Oferta> ofertas;
        public CompraDeOferta()
        {
            InitializeComponent();
        }

        private void dataGridCompraOfertas_Load(object sender, DataGridViewCellEventArgs e)
        {}

        private void dataGridCompraOfertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ofertaAComprar = (int)dataGridCompraOfertas.Rows[e.RowIndex].Cells[0].Value;
            Oferta ofertaObjeto = this.ofertas.Find(a => a.id.Equals(ofertaAComprar));

            this.compraOferta(ofertaObjeto);
        }

        private void CompraDeOferta_Load(object sender, EventArgs e)
        {
          
            ofertas = FuncionesOferta.getOfertasNoVencidas();
            foreach (Oferta oferta in ofertas)
            {
                Object[] row = new Object[] { oferta.proveedor_id, oferta.descripcion, oferta.precio_oferta, oferta.cantidad, oferta.maximo_usuario };
                dataGridCompraOfertas.Rows.Add(row);
            }

        }

        private void compraOferta(Oferta oferta) {
            int idCliente = ConectorDB.FuncionesCliente.getClienteLogueado();

            Cliente cliente = ConectorDB.FuncionesCliente.traerCliente(idCliente);

            decimal codigoCupon = ConectorDB.FuncionesOferta.comprarOferta(oferta, cliente);

            if (codigoCupon == -1) {
                MessageBox.Show("Alcanzo su limite compra", "Alcanzo su limite compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (codigoCupon == -2)
            {
                MessageBox.Show("No tiene credito suficiente", "No tiene credito suficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                MessageBox.Show("CODIGO CUPON: " + codigoCupon.ToString(), "Cupon comprado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        


    }
}
