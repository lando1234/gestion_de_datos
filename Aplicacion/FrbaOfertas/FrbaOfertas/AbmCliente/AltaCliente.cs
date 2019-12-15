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
using FrbaOfertas.Utils;

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
            try
            {
                this.validar();
                Direccion direccion = new Direccion(null, txt_ciudad.Text, txt_calle.Text, Int16.Parse(txt_cpostal.Text));
                Cliente cliente = new Cliente(null, int.Parse(txt_dni.Text), txt_nombre.Text, txt_apellido.Text, txt_mail.Text, int.Parse(txt_tel.Text), dateTimePicker.Value, true, null, direccion);
                ConectorDB.FuncionesCliente.altaCliente(cliente, usuario);
                if (this.usuario != null) {
                    new LoginConRegistro().Show();
                } 
            }
            catch (System.ArgumentException ex)
            {

                MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validar()
        {
            if (!Validador.isNumeric(txt_cpostal.Text))
            {
                throw new System.ArgumentException("Codigo postal debe ser númerico", "original");

            }
            else if (!Validador.isNumeric(txt_dni.Text))
            {
                throw new System.ArgumentException("Codigo postal debe ser númerico", "original");
            }
            else if (!Validador.IsValidEmail(txt_mail.Text))
            {
                throw new System.ArgumentException("el mail debe ser válido", "original");
            }
            else if (!Validador.isNumeric(txt_tel.Text))
            {
                throw new System.ArgumentException("el telefono debe ser númerico", "original");
            }
            else if (Validador.isEmpty(txt_nombre.Text) || Validador.isEmpty(txt_apellido.Text) || Validador.isEmpty(txt_mail.Text) ||
              Validador.isEmpty(txt_tel.Text) || Validador.isEmpty(txt_ciudad.Text) || Validador.isEmpty(txt_calle.Text) || Validador.isEmpty(txt_cpostal.Text) ){
                  throw new System.ArgumentException("Los campos no deben ir vacios", "original");
            }


        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

    }
}
