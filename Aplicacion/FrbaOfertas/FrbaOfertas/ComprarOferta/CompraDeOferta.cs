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
        List<Oferta> ofertas = new List<Oferta>();
        public CompraDeOferta()
        {
            InitializeComponent();
        }

        private void dataGridCompraOfertas_Load(object sender, DataGridViewCellEventArgs e)
        {

            List<Oferta> ofertas = FuncionesOferta.getOfertasNoVencidas();
            //ACA SE AGREGAN LAS OFERTAS AL DATA GRID PARA MOSTRARSE
            foreach (Oferta oferta in ofertas)
            {
              Object[] row = new Object[] { oferta.proveedor_id, oferta.descripcion, oferta.precio_oferta, oferta.cantidad, oferta.maximo_usuario };
              dataGridCompraOfertas.Rows.Add(row);
            }
        }

        private void dataGridCompraOfertas_CellContentClick()
        {
        }


    }
}
