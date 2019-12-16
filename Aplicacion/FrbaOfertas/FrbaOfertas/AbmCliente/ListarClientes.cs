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

namespace FrbaOfertas.AbmCliente
{
    public partial class ListarClientes : Form
    {
        List<Cliente> clientes;
        public ListarClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ListarClientes_Load(object sender, EventArgs e)
        {
            clientes = FuncionesCliente.getClientes();
            //ACA SE AGREGAN LOS CLIENTES AL DATA GRID PARA MOSTRARSE
            foreach (Cliente cliente in clientes)
            {
                Object[] row = new Object[] { cliente.id, cliente.nombre, cliente.apellido, cliente.dni, cliente.mail, cliente.telefono, cliente.fecha_nacimiento
                , cliente.direccion.Calle , null, null, cliente.direccion.Ciudad, null, cliente.habilitado};
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int idClienteAModif = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Cliente clienteAModifObj = clientes.Find(a => a.id.Equals(idClienteAModif));

            Form modificacion = new ModificarCliente(clienteAModifObj);
            modificacion.Show();
        }
    }
}
