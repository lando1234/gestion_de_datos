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
    public partial class FacturarSeleccionFechas : Form
    {
        Proveedor proveedor;

        public FacturarSeleccionFechas(Proveedor proveedor)
        {
            this.proveedor = proveedor;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factura factura = ConectorDB.FuncionesProveedor.facturarProveedor(proveedor.id, fechaDesde.Value, fechaHasta.Value);
            MessageBox.Show("Se facturo correctamente", "Factura Nro: " +factura.numero + "\n Importe: "+ factura.importe, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
