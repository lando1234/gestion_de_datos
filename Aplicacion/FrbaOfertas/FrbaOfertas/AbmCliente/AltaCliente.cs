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
            
            if (Validador.isNumeric(txt_cpostal.Text))
            {

                //0sageBox.Show("Codigo postal debe ser númerico", "PC NOT NUMERIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new System.ArgumentException("Codigo postal debe ser númerico", "original");
                
            }
            else if (Validador.isNumeric(txt_dni.Text))
            {
                MessageBox.Show("dni debe ser númerico", "DNI NOT NUMERIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
            else if (Validador.IsValidEmail(txt_mail.Text))
            {
                MessageBox.Show("el mail debe ser válido", "EMAIL NOT VALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else if (Validador.IsValidEmail(txt_tel.Text))
            {
                MessageBox.Show("el telefono debe ser númerico", "TEL NOT VALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {

                Direccion direccion = new Direccion(null, txt_ciudad.Text, txt_calle.Text, Int16.Parse(txt_cpostal.Text));
                Cliente cliente = new Cliente(null, int.Parse(txt_dni.Text), txt_nombre.Text, txt_apellido.Text, txt_mail.Text, int.Parse(txt_tel.Text), dateTimePicker.Value, true, null, direccion);
                ConectorDB.FuncionesCliente.altaCliente(cliente, usuario);
              
            }

     
    }


    }
    
}
