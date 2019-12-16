using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.BaseDeDatos;
using System.Data.SqlClient;
using System.Data;
using FrbaOfertas.ConectorDB;
using FrbaOfertas.Modelo.Roles;
using FrbaOfertas.AbmProveedor;

namespace FrbaOfertas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginConRegistro());
        }
    }
}
