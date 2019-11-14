using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelIniciarSesion_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            Console.WriteLine("LOGIN BUTTON CLICK");

            if (FrbaOfertas.Utils.ProtocoloLogin.protocoloLogin(textBoxLoginUser.Text, textBoxLoginPassword.Text))
            {
               FrbaOfertas.Modelo.Usuario.IngresoUsuario(textBoxLoginUser.Text, textBoxLoginPassword.Text);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrbaOfertas.RegistroForm.Registro dialog = new FrbaOfertas.RegistroForm.Registro();
            dialog.ShowDialog(this);
        }
    }
}
