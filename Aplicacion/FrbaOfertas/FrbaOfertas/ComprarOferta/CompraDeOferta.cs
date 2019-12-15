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

          
        }

        private void dataGridCompraOfertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridCompraOfertas.Columns["Comprar"].Index && (dataGridCompraOfertas.Rows.Count > 1) && e.RowIndex != dataGridCompraOfertas.Rows.Count - 1) {

                Oferta oferta = new Oferta();
               int idProveedor = Int32.Parse(dataGridCompraOfertas.Rows[e.RowIndex].Cells["Proveedor"].Value.ToString());


               FrbaOfertas.ComprarOferta.Form1 dialog = new FrbaOfertas.ComprarOferta.Form1(oferta);
               dialog.ShowDialog(this);
            }
        }

        private void CompraDeOferta_Load(object sender, EventArgs e)
        {
          
            
            List<Oferta> ofertas = FuncionesOferta.getOfertasNoVencidas();
            //ACA SE AGREGAN LAS OFERTAS AL DATA GRID PARA MOSTRARSE
            foreach (Oferta oferta in ofertas)
            {
                Object[] row = new Object[] { oferta.proveedor_id, oferta.descripcion, oferta.precio_oferta, oferta.cantidad, oferta.maximo_usuario };
                dataGridCompraOfertas.Rows.Add(row);
            }

        }

        


    }
}
