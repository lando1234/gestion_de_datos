using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cargarComboFunciones();
        }

        private void cargarComboFunciones()
        {
            input_funcionalidades.Items.Clear();
            foreach (String listing in FrbaOfertas.ConectorDB.FuncionesRol.ObtenerFuncionalidades())
            {
                input_funcionalidades.Items.Add(listing);
            }
        }

        private void guardar(object sender, EventArgs e)
        {
            List<String> funcionalidadesSeleccionadas = new List<string>();

            for (int i = 0; i < input_funcionalidades.Items.Count; i++){
                if (input_funcionalidades.GetItemChecked(i)){
                    string str = (string)input_funcionalidades.Items[i];
                    funcionalidadesSeleccionadas.Add(str);
                }
            }

            ConectorDB.FuncionesRol.GuardarRol(input_nombre.Text, funcionalidadesSeleccionadas);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            input_nombre.Clear();

            while (input_funcionalidades.CheckedIndices.Count > 0)
                input_funcionalidades.SetItemChecked(input_funcionalidades.CheckedIndices[0], false);
    
         }
    }
}
