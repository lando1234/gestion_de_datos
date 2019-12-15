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

        private void abmRolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            List<Rol> roles = Session.UserSession.roles;
            List<Permiso> permisos = new List<Permiso>();
            List<String> clavesPermisos = new List<String>();

            foreach (Rol rol in roles)
            {
                foreach (Permiso permiso in rol.permisos)
                {
                    permisos.Add(permiso);
                }
            }

            foreach (Permiso permiso in permisos)
            {
                clavesPermisos.Add(permiso.clave);
            }
            
            
            abmCliente.Visible = clavesPermisos.Contains("ABM_CLIENTES");
            abmProveedor.Visible = clavesPermisos.Contains("ABM_PROVEEDORES");
            abmRol.Visible = clavesPermisos.Contains("ABM_ROLES");
            CargaCredito.Visible = clavesPermisos.Contains("CARGAR_CREDITO");
            facturacion.Visible = clavesPermisos.Contains("FACTURAS");
            estadisticas.Visible = clavesPermisos.Contains("REPORTES");

            Ofertas.Visible = clavesPermisos.Contains("ABM_CLIENTES");
            
            ComprarOferta.Visible =  clavesPermisos.Contains("COMPRAR_OFERTA");
            crearOfertaProv.Visible = clavesPermisos.Contains("CREAR_OFERTA");

//              CANJEAR_OFERTA
        }

        private void Ofertas_Click(object sender, EventArgs e)
        {

        }

    }
}
