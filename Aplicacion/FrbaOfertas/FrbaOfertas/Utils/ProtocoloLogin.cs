using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Modelo;
using FrbaOfertas.Modelo.Roles;

namespace FrbaOfertas.Utils
{
    class ProtocoloLogin
    {

        public static Boolean protocoloLogin(string username, string password)
        {
            int Respuesta = FrbaOfertas.ConectorDB.FuncionesUsername.validLogin(username, password);
            switch (Respuesta)
            {
                case -1:
                    //usuario no encontrado
                    MessageBox.Show("Username no encontrado, registrese o intente nuevamente", "USERNAME NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case -2:
                    //reintentos bloqueado
                    MessageBox.Show("El usuario se encuentra bloqueado por superar el numero de logins incorrectos, comuniquese con un administrativo", "USUARIO BLOQUEADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case -3:
                    //fallo el intento sin bloquearse
                    MessageBox.Show("Password Incorrecta numero de intentos aumentado", "PASSWORD INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case -4:
                    MessageBox.Show("El usuario se encuentra inhabilitado, comuniquese con un administrativo", "USUARIO INHABILITADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                default:
                    if (Respuesta > 0)
                    {
                        //SETEAR EL USUARIO DE FORMA GLOBAL
                        Session.UserSession = ConectorDB.FuncionesUsername.getUserById(Respuesta);

                        return true;
                    }
                    else
                    {
                        return false;
                    }

            }
        }

    }
}
