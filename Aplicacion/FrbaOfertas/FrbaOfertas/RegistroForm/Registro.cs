using FrbaOfertas.Modelo;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(textUsuario.Text.Length == 0 ){
                MessageBox.Show("El usuario no puede estar vacio", "PASSWORD INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textPass1.Text != textPass2.Text) {
                MessageBox.Show("La password no coincide", "PASSWORD INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario usuarioNuevo = new Usuario();
            usuarioNuevo.username = textUsuario.Text;
            usuarioNuevo.password = textPass1.Text;

            if (comboTipo.Text == "Cliente") {
                Form alta = new AbmCliente.AltaCliente(usuarioNuevo);
                alta.Show();
            }

            if (comboTipo.Text == "Proveedor") {
                Form alta = new AbmProveedor.AltaProveedor(usuarioNuevo);
                alta.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
