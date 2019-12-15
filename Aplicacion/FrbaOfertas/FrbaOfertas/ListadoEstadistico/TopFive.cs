using FrbaOfertas.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.ConectorDB;
using FrbaOfertas.Modelo;

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class TopFive : Form
    {
        public TopFive()
        {
            InitializeComponent();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

            int minimoAnio = FrbaOfertas.ConectorDB.ObtenerRangoAñosFacturas.obtenerMinimoAño();
            int maximoAnio = FrbaOfertas.ConectorDB.ObtenerRangoAñosFacturas.obtenerMaximoAño();
            for (int i = minimoAnio; i <= maximoAnio; i++)
            {
                cboAños.Items.Add(i);
            }
            radioBtnPRIMERO.Checked = true;
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            this.dataGridViewListadoFACTURAS.DataSource = null;
            this.dataGridViewListadoFACTURAS.Rows.Clear();
            this.dataGridViewListadoOFERTAS.DataSource = null;
            this.dataGridViewListadoOFERTAS.Rows.Clear();
            radioBtnPRIMERO.Checked = true;

        }

        private void cmdListadoOFERTAS_Click(object sender, EventArgs e)
        {
            if (this.validarDatos())
            {


                this.dataGridViewListadoOFERTAS.Visible = true;
                this.dataGridViewListadoFACTURAS.Visible = false;

                int anio = (int) cboAños.SelectedItem;

                DateTime rango_inf = new DateTime(0, 0, 0);
                DateTime rango_sup = new DateTime(0, 0, 0);
                if (radioBtnPRIMERO.Checked == true)
                {
                    rango_inf = new DateTime(anio, 01, 01);
                    rango_sup = new DateTime(anio, 06, 30);
                }
                else if (radioBtnSEGUNDO.Checked == true)
                {
                    rango_inf = new DateTime(anio, 07, 01);
                    rango_sup = new DateTime(anio, 12, 30);
                }
             

                this.dataGridViewListadoOFERTAS.DataSource = null;
                this.dataGridViewListadoOFERTAS.Rows.Clear();
                dataGridViewListadoOFERTAS.Refresh();
            

              IList <ProveedorValor> proveedores =  ListadoEstadisticas.getMasPorcentaje(rango_inf,rango_sup);
                if(proveedores.Count > 0){
                    foreach (ProveedorValor proveedor in proveedores )
                    {
                        int id = proveedores.IndexOf(proveedor);
                        
                        dataGridViewListadoOFERTAS.Rows.Add();
                        dataGridViewListadoOFERTAS.Rows[id].Cells[0].Value = id; //reader["ID PROVEEDOR"].ToString();
                        dataGridViewListadoOFERTAS.Rows[id].Cells[1].Value = proveedor.razonSocial;// reader["Razon Social"].ToString();
                        dataGridViewListadoOFERTAS.Rows[cont].Cells[2].Value = ;  //reader["Cantidad Ofertas Realizadas"].ToString();
                        dataGridViewListadoOFERTAS.Rows[cont].Cells[3].Value = proveedor.monto;
                        cont++;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados para ese año");
                }

                
            }

        }

        private void cmdListadoFACTURACION_Click(object sender, EventArgs e)
        {
            if (this.validarDatos())
            {

                this.dataGridViewListadoOFERTAS.Visible = false;
                this.dataGridViewListadoFACTURAS.Visible = true;

                int anio = (int)cboAños.SelectedItem;

                DateTime rango_inf = new DateTime(0, 0, 0);
                DateTime rango_sup = new DateTime(0, 0, 0);
                if (radioBtnPRIMERO.Checked == true)
                {
                    rango_inf = new DateTime(anio, 01, 01);
                    rango_sup = new DateTime(anio, 06, 30);
                }
                else if (radioBtnSEGUNDO.Checked == true)
                {
                    rango_inf = new DateTime(anio, 07, 01);
                    rango_sup = new DateTime(anio, 12, 30);
                }


                this.dataGridViewListadoFACTURAS.DataSource = null;
                this.dataGridViewListadoFACTURAS.Rows.Clear();
                dataGridViewListadoFACTURAS.Refresh();


                IList<ProveedorValor> proveedores = ListadoEstadisticas.getMasFacturacion(rango_inf, rango_sup);
     
                if(proveedores.Count > 0){
                    foreach (ProveedorValor proveedor in proveedores ){
                        int id = proveedores.IndexOf(proveedor);

                        dataGridViewListadoFACTURAS.Rows.Add();
                        dataGridViewListadoFACTURAS.Rows[id].Cells[0].Value = id; //reader["ID PROVEEDOR"].ToString();
                        dataGridViewListadoFACTURAS.Rows[id].Cells[1].Value = proveedor.razonSocial;//reader["Razon Social"].ToString();
                        dataGridViewListadoFACTURAS.Rows[cont].Cells[2].Value = reader["Total Facturado"].ToString();
                        dataGridViewListadoFACTURAS.Rows[cont].Cells[3].Value = proveedor.monto;//reader["Cantidad de Facturas"].ToString();
                        cont++;
                    
                    }

                }
                else
                {
                    MessageBox.Show("No se encontraron resultados para ese año");
                }

               
            }
        }


        private bool validarDatos()
        {
            if (cboAños.Text == "")
            {
                MessageBox.Show("Seleccione un año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
