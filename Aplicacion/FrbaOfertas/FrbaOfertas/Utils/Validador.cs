using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FrbaOfertas.Utils
{
    static class Validador
    {

        static public Boolean existeDNIenDB(String dni)
        {
            return FrbaOfertas.ConectorDB.FuncionesCliente.existeDNI(dni);
        }

        static public Boolean existeMailenDB(String mail)
        {
            return FrbaOfertas.ConectorDB.FuncionesCliente.existeMail(mail);
        }

        static public Boolean containsNumber(String palabra)
        {
            palabra = palabra.Trim();
            return palabra.Any(char.IsNumber);
        }

        static public Boolean isEmpty(String palabra)
        {
            //Estos son mensajes de error de no estar aca podrian crearse usuario con username = "El campo ya existe"
            if (palabra == "El campo ya existe" || palabra == "Falta completar campo" || palabra == "El Campo ingresado ya existe en la base de datos" || palabra == "El Rol ya existe"
               || palabra == "El Campo no debe contener numeros" || palabra == "El Campo no debe contener Letras" || palabra == "El Campo supera el rango maximo de caracteres" || palabra == "Usá el formato nombre@ejemplo.com"
               || palabra == "El usuario ya existe")
            {
                return true;
            }
            if (palabra != "") { palabra = palabra.Trim(); }
            return palabra == "";
        }

        static public Boolean isNumeric(String palabra)
        {
            palabra = palabra.Trim();
            return palabra.All(char.IsNumber);
        }

        static public Boolean superaCantidadCaracteres(String palabra, int length)
        {
            palabra = palabra.Trim();
            return palabra.Length > length;
        }

        static public Boolean fueraDeRango(String palabra, int inf, int sup)
        {
            palabra = palabra.Trim();
            return (palabra.Length > sup) || (palabra.Length < inf);
        }

        static public Boolean IsValidEmail(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                return (addr.Address == email) && (email.Contains(".com"));
            }
            catch
            {
                return false;
            }
        }

       static public Boolean FechaFutura(DateTime fechaDelDateTimePicker)
        {
            return DateTime.Compare(fechaDelDateTimePicker, HoraSistema.get()) > 0;
        }

        static public void textoDeError(TextBox textbox, string texto)
        {
            textbox.Text = texto;
            textbox.ForeColor = Color.Red;
        }

        static public void ErrorFaltaCompletarCampo(TextBox textbox)
        {
            textoDeError(textbox, "Falta completar campo");
        }
        static public void ErrorCampoYaExisteEnLaBase(TextBox textbox)
        {
            textoDeError(textbox, "El Campo ingresado ya existe en la base de datos");
        }
        static public void ErrornoContenerNumeros(TextBox textbox)
        {
            textoDeError(textbox, "El Campo no debe contener numeros");
        }
        static public void ErrornoContenerLetras(TextBox textbox)
        {
            textoDeError(textbox, "El Campo no debe contener Letras");
        }
        static public void ErrorYaExisteRol(TextBox textbox)
        {
            textoDeError(textbox, "El Rol ya existe");
        }

        static public void ErrorSuperaRango(TextBox textbox)
        {
            textoDeError(textbox, "El Campo supera el rango maximo de caracteres");
        }
        static public void ErrorEmail(TextBox textbox)
        {
            textoDeError(textbox, "Usá el formato nombre@ejemplo.com");
        }
        static public void ErrorCuitLongitud(TextBox textbox)
        {
            textoDeError(textbox, "Utilice el formato tipo-DNI-DigitoVerificador, 11 numeros");
        }

        static public void crearCajaDeError(string texto, string titulo)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //creo esta funcion ya que hay muchos campos que necesitan validar estas mismas propiedades (nombre, apellido, calle, etc)
        static public Boolean validaCadenaCaracter(TextBox textbox, Boolean pass)
        {
            if (isEmpty(textbox.Text))
            {
                ErrorFaltaCompletarCampo(textbox);
                pass = false;
            }
            else if (containsNumber(textbox.Text))
            {
                ErrornoContenerNumeros(textbox);
                pass = false;
            }
            else if (fueraDeRango(textbox.Text, 0, 255))
            {
                ErrorSuperaRango(textbox);
                pass = false;
            }
            return pass;

        }
        static public Boolean validacionDni(TextBox textboxDni, Boolean pass)
        {
            if (isEmpty(textboxDni.Text))
            {
                ErrorFaltaCompletarCampo(textboxDni);
                pass = false;
            }
            else if (!isNumeric(textboxDni.Text))
            {
                ErrornoContenerLetras(textboxDni);
                pass = false;
            }
            else if (fueraDeRango(textboxDni.Text, 8, 9))
            {
                ErrorSuperaRango(textboxDni);
                pass = false;
            }
            else if (existeDNIenDB(textboxDni.Text))
            {
                ErrorCampoYaExisteEnLaBase(textboxDni);
                pass = false;
            }
            return pass;

        }
        static public Boolean validarCuit(TextBox TBcuit, Boolean pass)
        {
            string cuit = TBcuit.Text.Replace("-", string.Empty);
            if (isEmpty(TBcuit.Text))
            {
                ErrorFaltaCompletarCampo(TBcuit);
                pass = false;
            }

            else if (!isNumeric(TBcuit.Text))
            {
                ErrornoContenerLetras(TBcuit);
                pass = false;
            }
            else if (cuit.Length != 11)
            {
                ErrorCuitLongitud(TBcuit);
                pass = false;
            }


            return pass;
        }
        static public void BorrarMensajeDeError(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "El campo ya existe" || textBox.Text == "Falta completar campo" || textBox.Text == "El Campo ingresado ya existe en la base de datos" || textBox.Text == "El Rol ya existe"
                || textBox.Text == "El Campo no debe contener numeros" || textBox.Text == "El Campo no debe contener Letras" || textBox.Text == "El Campo supera el rango maximo de caracteres" || textBox.Text == "Usá el formato nombre@ejemplo.com")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

    }
}
