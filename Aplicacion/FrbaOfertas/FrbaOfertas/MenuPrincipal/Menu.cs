using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.MenuPrincipal
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void altaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form alta = new AbmCliente.AltaCliente();
            alta.Show();
        }

        private void listarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AbmCliente.ListarClientes();
            form.Show();
        }

        private void altaProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AbmProveedor.AltaProveedor();
            form.Show();
        }

        private void listarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AbmProveedor.ListarProveedor();
            form.Show();
        }

        private void altaRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AbmRol.AltaRol();
            form.Show();
        }

        private void listarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AbmRol.ListaRoles();
            form.Show();
        }

        private void recargaCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new CargaDeCredito.RecargarCredito();
            form.Show();
        }

        private void comprarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new ComprarOferta.CompraDeOferta();
            form.Show();
        }

        private void crearOfertaAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new CrearOferta.CrearOfertaAdministrativo();
            form.Show();
        }

        private void crearOfertaProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new CrearOferta.CrearOfertaProveedor();
            form.Show();
        }

        private void facturarAProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Facturar.FacturarAProveedor();
            form.Show();
        }

        private void top5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ListadoEstadistico.TopFive();
            form.Show();
        }

    }
}
