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

namespace FrbaOfertas.Facturar
{
    public partial class FacturarListaProveedores : Form
    {

        List<Proveedor> proveedores;

        public FacturarListaProveedores()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //buscar
        }

        private void FacturarListaProveedores_Load(object sender, EventArgs e)
        {
            this.proveedores = ConectorDB.FuncionesProveedor.getProveedores();
            foreach (Proveedor prov in proveedores)
            {
                Object[] row = new Object[] { 
                    prov.id,
                    prov.RazonSocial,
                    prov.cuit,
                    prov.mail,
                    prov.telefono,
                    prov.direccion.Calle,
                    prov.direccion.Ciudad,
                    prov.direccion.codigoPostal,
                    prov.nombreContacto,
                    prov.rubro.descripcion,
                    prov.habilitado
                };
                dataGridProveedoresAFacturar.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int proveedorAFacturar = (int)dataGridProveedoresAFacturar.Rows[e.RowIndex].Cells[0].Value;
            Proveedor proveedorSeleccionadoAFacturar = this.proveedores.Find(a => a.id.Equals(proveedorAFacturar));

            Form modificacion = new FacturarSeleccionFechas(proveedorSeleccionadoAFacturar);
            modificacion.Show();
        }
    }
}
