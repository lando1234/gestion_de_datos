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
using FrbaOfertas.Modelo;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        Usuario usuario;
        public AltaProveedor(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        public AltaProveedor()
        {
            InitializeComponent();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            
            Proveedor proveedor = new Proveedor();
            proveedor.RazonSocial = txt_razonsocial.Text;
            proveedor.direccion = new Direccion(null, txt_ciudad.Text, txt_calle.Text, Int16.Parse(txt_codpostal.Text));
            proveedor.cuit = txt_cuit.Text;
            proveedor.telefono = txt_tel.Text;
            proveedor.rubro = (Rubro) comboRubro.SelectedItem;
            proveedor.nombreContacto = txt_nombreContacto.Text;
            proveedor.mail = txt_mail.Text;

            ConectorDB.FuncionesProveedor.altaUsuarioProveedor(proveedor, usuario);
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            List<Rubro> rubros = ConectorDB.FuncionesRubro.getRubros();
           
            foreach (Rubro rubro in rubros)
            {
                comboRubro.Items.Add(rubro);
            }
            
        }
    }
}
