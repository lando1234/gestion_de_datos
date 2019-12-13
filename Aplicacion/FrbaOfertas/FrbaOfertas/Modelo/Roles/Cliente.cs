using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    public class Cliente
    {
        public Nullable<int> id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public Boolean habilitado { get; set; }
        public Nullable<int> usuarioId { get; set; }
        public Direccion direccion { get; set; }



        public Cliente(Nullable<int> id, int dni, string nombre, string apellido, string mail, int telefono,
            DateTime fecha_nacimiento, Boolean habilitado, Nullable<int> usuarioId, Direccion direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.dni = dni;
            this.apellido = apellido;
            this.mail = mail;
            this.telefono = telefono;
            this.fecha_nacimiento = fecha_nacimiento;
            this.habilitado = habilitado;
            this.usuarioId = usuarioId;
            this.direccion = direccion;
            
        }
    }
}
