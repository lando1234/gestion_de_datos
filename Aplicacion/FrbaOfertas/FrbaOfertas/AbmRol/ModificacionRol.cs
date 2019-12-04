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
    public partial class ModificacionRol : Form
    {

        private String rolAModificar;

        public ModificacionRol(String rol)
        {
            this.rolAModificar = rol;
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            List<String> funcionalidadesSeleccionadas = new List<string>();

            for (int i = 0; i < listBoxFuncionalidades.Items.Count; i++)
            {
                if (listBoxFuncionalidades.GetItemChecked(i)){
                    string str = (string)listBoxFuncionalidades.Items[i];
                    funcionalidadesSeleccionadas.Add(str);
                }
            }

            ConectorDB.FuncionesRol.UpdatearRol(textNombre.Text, rolAModificar, checkBoxHabilitado.Checked ,funcionalidadesSeleccionadas);
        }

        private void ModificacionRol_Load(object sender, EventArgs e)
        {
            textNombre.Text = rolAModificar;
            listBoxFuncionalidades.Items.Clear();
            List<String> funcionalidadesDeRol = FrbaOfertas.ConectorDB.FuncionesRol.ObtenerFuncionalidadesDeUnRol(this.rolAModificar);
            List<String> todasLasFuncionalidades = FrbaOfertas.ConectorDB.FuncionesRol.ObtenerFuncionalidades();
            foreach (String listing in funcionalidadesDeRol)
            {
                listBoxFuncionalidades.Items.Add(listing);
            }
            for (int i = 0; i < listBoxFuncionalidades.Items.Count; i++)
            {
                listBoxFuncionalidades.SetItemChecked(i, true);
            }
            List<String> funcionalidadesAAgregar = todasLasFuncionalidades.Where(x => !funcionalidadesDeRol.Contains(x)).ToList();
            foreach (String listing in funcionalidadesAAgregar)
            {
                listBoxFuncionalidades.Items.Add(listing);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textNombre.Clear();

            for (int i = 0; i < listBoxFuncionalidades.Items.Count; i++)
            {
                listBoxFuncionalidades.SetItemChecked(i, false);
            }
        }


    }
}
