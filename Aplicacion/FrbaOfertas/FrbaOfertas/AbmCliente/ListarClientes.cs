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
        public ListarClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ListarClientes_Load(object sender, EventArgs e)
        {
            List<Cliente> clientes = FuncionesCliente.getClientes();
            //ACA SE AGREGAN LOS CLIENTES AL DATA GRID PARA MOSTRARSE
            foreach (Cliente cliente in clientes)
            {
                Object[] row = new Object[] { cliente.id, cliente.nombre, cliente.apellido, cliente.dni, cliente.mail, cliente.telefono, cliente.fecha_nacimiento
                , null, null, null, cliente.direccion, null, cliente.habilitado};
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
