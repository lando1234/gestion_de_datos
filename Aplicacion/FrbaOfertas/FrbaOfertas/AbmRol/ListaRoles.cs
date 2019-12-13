using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Modelo.Roles;

namespace FrbaOfertas.AbmRol
{
    public partial class ListaRoles : Form
    {
        List<Rol> roles = new List<Rol>();

        public ListaRoles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ListaRoles_Load(object sender, EventArgs e)
        {

            roles = ConectorDB.FuncionesRol.obtenerRoles();
            
            //ACA SE AGREGAN LOS ROLES AL DATA GRID PARA MOSTRARSE
            foreach(Rol rols in roles){
                Object[] row = new Object[] { rols.id, rols.nombre, rols.habilitado };
                dataGridRol1.Rows.Add(row);
            }

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //nombreRolBuscar.Text;
        }

        private void dataGridRol1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rolIdAModificar = (int)dataGridRol1.Rows[e.RowIndex].Cells[0].Value;
            Rol rolAModificar = roles.Find(a => a.id.Equals(rolIdAModificar));

            Form modificacion = new ModificacionRol(rolAModificar);
            modificacion.Show();
        }

    }
}
