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
    public partial class CrearOfertaAdministrativo : Form
    {
        public CrearOfertaAdministrativo()
        {
            InitializeComponent();
        }


        private void CrearOfertaAdministrativo_Load(object sender, EventArgs e)
        {
            foreach(Proveedor p in FuncionesProveedor.getProveedoresHabilitados()) {
                comboBox1.Items.Add(p);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.validar();

            Oferta oferta = new Oferta();
            oferta.maximo_usuario = Int32.Parse(maxCliente.Text);
            oferta.codigo = txt_codigo.Text;
            oferta.descripcion = txt_descripcion.Text;
            oferta.fecha_publicacion = dateTimePickerOferta.Value;
            oferta.fecha_vencimiento = dateTimePickerVencimiento.Value;
            oferta.cantidad = Int32.Parse(cantidad.Text);
            oferta.precio_lista = Int32.Parse(precioLista.Text);
            oferta.precio_oferta = Int32.Parse(precioOferta.Text);
            oferta.proveedor_id = Int32.Parse(comboBox1.Text);

            FuncionesOferta.altaOferta(oferta);
            

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
