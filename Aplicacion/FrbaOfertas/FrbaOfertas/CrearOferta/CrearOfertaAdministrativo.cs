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
    public partial class CrearOfertaAdministrativo : Form
    {
        public CrearOfertaAdministrativo()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.validar();

            Oferta oferta = new Oferta();
            oferta.maximo_usuario = Int32.Parse(txt_maxUnidadesPorCliente.Text);
            oferta.codigo = txt_codigo.Text;
            oferta.descripcion = txt_descripcion.Text;
            oferta.fecha_publicacion = dateTimePickerOferta.Text;
            oferta.fecha_vencimiento = dateTimePickerVencimiento.Text;
            oferta.cantidad = Int32.Parse(txt_cantidad.Text);
            oferta.precio_lista = txt_precioLista.Text;
            oferta.precio_oferta = txt_precioOferta.Text;
            oferta.proveedor_id = Int32.Parse(comboBox1.Text);

            

        }

        private void validar()
        {
            //TODO
            throw new NotImplementedException();
        }

        private void txt_precioOferta_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Detalles_Enter(object sender, EventArgs e)
        {

        }
    }
}
