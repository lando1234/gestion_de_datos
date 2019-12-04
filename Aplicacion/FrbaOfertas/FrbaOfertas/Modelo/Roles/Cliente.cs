using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    public class Cliente : Rol
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int telefono { get; set; }
        public string fecha_nacimiento { get; set; }
        public Boolean habilitado { get; set; }
        public int usuarioId { get; set; }
        public int direccionId { get; set; }


        public Cliente(int id, int dni, string nombre, string apellido, string mail, int telefono,
            string fecha_nacimiento, Boolean habilitado, int usuarioId, int direccionId)
        {
            this.id = id;
            this.dni = dni;
            this.apellido = apellido;
            this.mail = mail;
            this.telefono = telefono;
            this.fecha_nacimiento = fecha_nacimiento;
            this.habilitado = habilitado;
            this.usuarioId = usuarioId;
            this.direccionId = direccionId;
            
        }


        public override int getIdentificadorPrincipal()
        {
            return this.dni;

        }
        public override string getName()
        {
            return typeof(Cliente).Name;
        }
        public override void Instertar()
        {
            //FrbaOfertas.ConectorDB.FuncionesCliente.altaCliente(this);

        }

        public override void Modificar()
        {
            throw new NotImplementedException();
        }

    }
}
