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
            Proveedor proveedor = new Proveedor();
            proveedor.RazonSocial = txt_razonsocial.Text;
            proveedor.Calle = txt_calle.Text;
            proveedor.Piso = txt_piso.Text;
            proveedor.Dpto = txt_dpto.Text;
            proveedor.Localidad = txt_localidad.Text;
            proveedor.Ciudad = txt_ciudad.Text;
            proveedor.codigoPostal = txt_codpostal.Text;
            proveedor.cuit = txt_cuit.Text;
            proveedor.telefono = txt_tel.Text;
            proveedor.rubro = txt_rubro.Text;
            proveedor.nombreContacto = txt_nombreContacto.Text;
        }
    }
}
