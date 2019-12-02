using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.BaseDeDatos;
using System.Data.SqlClient;
using System.Data;
using FrbaOfertas.ConectorDB;



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
        //  Application.Run(new LoginForm());
          
             List<String> lista = new List<String>();


             lista = FuncionesRol.ObtenerFuncionalidades();
          Console.WriteLine("Element[{0}]",lista[0]);
            
        
           


        }
    }
}
