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
                oferta.maximo_usuario = Int32.Parse(txt_maxUnidadesPorCliente.Text);
                oferta.codigo = txt_codigo.Text;
                oferta.descripcion = txt_descripcion.Text;
                oferta.fecha_publicacion = dateTimePickerOferta.Text;
                oferta.fecha_vencimiento = dateTimePickerVencimiento.Text;
                oferta.cantidad = Int32.Parse(txt_cantidad.Text);
                oferta.precio_lista = txt_precioLista.Text;
                oferta.precio_oferta = txt_precioOferta.Text;
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
