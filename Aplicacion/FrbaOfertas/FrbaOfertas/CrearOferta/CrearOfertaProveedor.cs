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

namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOfertaProveedor : Form
    {
        public CrearOfertaProveedor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Oferta oferta = new Oferta();
                oferta.maximo_usuario = Int32.Parse(maxUnidades.Text);
                oferta.codigo = txt_codigo.Text;
                oferta.descripcion = txt_descripcion.Text;
                oferta.fecha_publicacion = dateTimePickerOferta.Value;
                oferta.fecha_vencimiento = dateTimePickerVencimiento.Value;
                oferta.cantidad = Int32.Parse(cantidad.Text);
                oferta.precio_lista = Int32.Parse(precioLista.Text);
                oferta.precio_oferta = Int32.Parse(precioOferta.Text);
                oferta.proveedor_id = FuncionesProveedor.getProveedorLogueado();

                FuncionesOferta.altaOferta(oferta);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("El Proveedor esta dado de baja", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
