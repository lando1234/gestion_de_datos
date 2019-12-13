using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Modelo.Roles;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        public AltaProveedor()
        {
            InitializeComponent();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            /*
            Proveedor proveedor = new Proveedor();
            proveedor.RazonSocial = txt_razonsocial.Text;
            proveedor.direccion = new Direccion(null, txt_ciudad.Text, txt_calle.Text, txt_codpostal.Text);
            proveedor.cuit = txt_cuit.Text;
            proveedor.telefono = txt_tel.Text;
            proveedor.rubro = (Rubro) comboRubro.SelectedItem;
            proveedor.nombreContacto = txt_nombreContacto.Text;
             * */
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
