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

namespace FrbaOfertas.Canje
{
    public partial class CanjearOferta : Form
    {
        List<Cupon> cupones;
        public CanjearOferta()
        {
            InitializeComponent();
        }

        private void CanjearOferta_Load(object sender, EventArgs e)
        {
            int idcliente = ConectorDB.FuncionesCliente.getClienteLogueado();
            cupones = ConectorDB.FuncionesConsumoCupones.obtenerCuponPorIdNoVencido(idcliente);

            //ACA SE AGREGAN LOS ROLES AL DATA GRID PARA MOSTRARSE
            foreach (Cupon rols in cupones)
            {
                Object[] row = new Object[] { rols.fechaConsumo, rols.id };
                dataGridViewCUPON.Rows.Add(row);
            }
        }

        private void dataGridViewCUPON_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rolIdAModificar = (int)dataGridViewCUPON.Rows[e.RowIndex].Cells[0].Value;
            Cupon rolAModificar = cupones.Find(a => a.id.Equals(rolIdAModificar));

            int val = ConectorDB.FuncionesConsumoCupones.consumirCupon(rolAModificar, Convert.ToInt32(provedorId.Text));

            MessageBox.Show("respuesta valor"+ val,"CUPON CANJEADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
