﻿using System;
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
    public partial class LoginConRegistro : Form
    {
        public LoginConRegistro()
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

            if (FrbaOfertas.Utils.ProtocoloLogin.protocoloLogin(textBoxLoginUser.Text, textBoxLoginPassword.Text))
            {
                //HACER LA VALIDACION DE LOS PERMISOS EN EL MENU PARA MOSTRAR SOLO QUE CORRESPONDE
                Form alta = new MenuPrincipal.Menu();
                alta.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrbaOfertas.RegistroForm.Registro dialog = new FrbaOfertas.RegistroForm.Registro();
            dialog.ShowDialog(this);
        }
    }
}
