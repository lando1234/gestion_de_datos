using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.RegistroForm
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void botonCancelar(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
