using FrbaOfertas.ConectorDB;
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

namespace FrbaOfertas.AbmProveedor
{
    public partial class ModificarProveedor : Form
    {
        Proveedor proveedorAModificar;
        public ModificarProveedor(Proveedor proveedor)
        {
             proveedorAModificar = proveedor;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txt_razonsocial.Text = proveedorAModificar.RazonSocial;
            txt_ciudad.Text = proveedorAModificar.direccion.Ciudad;
            txt_codpostal.Text = proveedorAModificar.direccion.codigoPostal.ToString();
            txt_mail.Text = proveedorAModificar.mail;
            txt_cuit.Text = proveedorAModificar.cuit;
            txt_tel.Text = proveedorAModificar.telefono.ToString();
            txt_rubro.Text = proveedorAModificar.rubro.descripcion;
            txt_nombreContacto.Text = proveedorAModificar.nombreContacto;
            checkBox1.Checked = Convert.ToBoolean(proveedorAModificar.habilitado);

        }

        private void Detalles_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //this.validar();
                Proveedor proveedor = new Proveedor(
                FuncionesProveedor.getProveedorLogueado(),
                txt_razonsocial.Text,
                txt_cuit.Text,
                txt_mail.Text,
                Convert.ToDecimal(txt_tel.Text),
               new Direccion(proveedorAModificar.direccion.id, txt_localidad.Text, txt_calle.Text, Convert.ToDecimal(txt_codpostal)),
                new Rubro (null, txt_rubro.Text),
                txt_nombreContacto.Text,
                checkBox1.Checked);

                FrbaOfertas.ConectorDB.FuncionesProveedor.editProveedor(proveedor);

                MessageBox.Show("Cliente modificado con exito", "Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.ArgumentException ex)
            {

                MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              
               
                this.Close();
            
        }
    }
}
