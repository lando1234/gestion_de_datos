using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOfertaProveedor : Form
    {
        public CrearOfertaProveedor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txt_precioLista.Text = "";
            this.txt_precioOferta.Text = "";
            this.txt_stockDisponible.Text = "";
            this.txt_maxUnidadesPorCliente.Text = "";
            this.txt_descripcion.Text = "";
            this.dateTimePickerOferta.Value = DateTime.Now;
            this.dateTimePickerVencimiento.Value = DateTime.Now;
        }
    }
}
