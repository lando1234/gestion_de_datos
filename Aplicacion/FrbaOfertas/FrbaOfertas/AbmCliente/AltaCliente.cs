using FrbaOfertas.Modelo;
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

namespace FrbaOfertas.AbmCliente
{
    public partial class AltaCliente : Form
    {
        Usuario usuario;

        public AltaCliente(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        public AltaCliente()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Direccion direccion = new Direccion(null, txt_ciudad.Text, txt_calle.Text, txt_cpostal.Text);
            Cliente cliente = new Cliente(null, int.Parse(txt_dni.Text), txt_nombre.Text, txt_apellido.Text, txt_mail.Text, int.Parse(txt_tel.Text), dateTimePicker.Value,true, null, direccion);
            ConectorDB.FuncionesCliente.altaCliente(cliente, usuario);
        }

    }
}
