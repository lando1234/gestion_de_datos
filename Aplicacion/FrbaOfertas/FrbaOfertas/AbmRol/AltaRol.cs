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
            foreach (Permiso listing in FrbaOfertas.ConectorDB.FuncionesRol.ObtenerFuncionalidades())
            {
                input_funcionalidades.Items.Add(listing);
            }
        }

        private void guardar(object sender, EventArgs e)
        {
            List<Permiso> funcionalidadesSeleccionadas = new List<Permiso>();

            for (int i = 0; i < input_funcionalidades.Items.Count; i++)
            {
                if (input_funcionalidades.GetItemChecked(i))
                {
                    Permiso str = (Permiso)input_funcionalidades.Items[i];
                    funcionalidadesSeleccionadas.Add(str);
                }
            }

            Rol nuevoRol = new Rol(null, input_nombre.Text, funcionalidadesSeleccionadas);

            ConectorDB.FuncionesRol.GuardarRol(nuevoRol);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            input_nombre.Clear();

            while (input_funcionalidades.CheckedIndices.Count > 0)
                input_funcionalidades.SetItemChecked(input_funcionalidades.CheckedIndices[0], false);
    
         }
    }
}
