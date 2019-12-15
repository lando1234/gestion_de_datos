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
using FrbaOfertas.Utils;

namespace FrbaOfertas.AbmCliente
{
    public partial class ModificarCliente : Form
    {
        Cliente clienteAModificar;
        public ModificarCliente(Cliente cliente)
        {
            clienteAModificar = cliente;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                Cliente cliente = new Cliente(
                FuncionesCliente.getClienteLogueado(),
                Convert.ToDecimal(txt_dni.Text),
                txt_nombre.Text,
                txt_apellido.Text,
                txt_mail.Text,
                Convert.ToDecimal(txt_tel.Text),
                dateTimePicker.Value,
                checkBox1.Checked,
                Session.UserSession.id,
                new Direccion(clienteAModificar.direccion.id, txt_localidad.Text, txt_calle.Text, null));

                FrbaOfertas.ConectorDB.FuncionesCliente.UpdateCliente(cliente);

                MessageBox.Show("Cliente modificado con exito", "Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.ArgumentException ex)
            {

                MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              
               
                this.Close();
            }

        private void Detalles_Enter(object sender, EventArgs e)
        {
        
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            txt_nombre.Text = clienteAModificar.nombre;
            txt_apellido.Text = clienteAModificar.apellido;
            txt_calle.Text = clienteAModificar.direccion.Calle;
            txt_dni.Text = clienteAModificar.dni.ToString();
            txt_localidad.Text = clienteAModificar.direccion.Ciudad;
            txt_mail.Text = clienteAModificar.mail;
            txt_tel.Text = clienteAModificar.telefono.ToString();
            dateTimePicker.Value = clienteAModificar.fecha_nacimiento;
            checkBox1.Checked = Convert.ToBoolean(clienteAModificar.habilitado);
        }

        private void validar()
        {
            if (!Validador.isNumeric(txt_dni.Text))
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
              Validador.isEmpty(txt_tel.Text) || Validador.isEmpty(txt_localidad.Text) || Validador.isEmpty(txt_calle.Text))
            {
                throw new System.ArgumentException("Los campos no deben ir vacios", "original");
            }


        }

        }
}

