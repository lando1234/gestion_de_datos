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
using FrbaOfertas.ConectorDB;

namespace FrbaOfertas.AbmProveedor
{
    public partial class ListarProveedor : Form
    {
        public ListarProveedor()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListarProveedor_Load(object sender, EventArgs e)
        {
            IList<Proveedor> proveedores = FuncionesProveedor.getProveedores();
            //ACA SE AGREGAN LOS CLIENTES AL DATA GRID PARA MOSTRARSE
            foreach (Proveedor proveedor in proveedores)
            {
                Object[] row = new Object[] { proveedor.id, proveedor.RazonSocial, proveedor.cuit, proveedor.mail, proveedor.telefono, proveedor.direccion.Calle, null, null, null ,
                    proveedor.direccion.Ciudad, proveedor.direccion.codigoPostal, proveedor.nombreContacto, proveedor.rubro, proveedor.habilitado};
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       

    }
}
