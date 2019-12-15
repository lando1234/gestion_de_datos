using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelo.Roles
{
    class Proveedor
    {
        public int id { get; set; }
        public string RazonSocial { get; set; }
        public string cuit { get; set; }
        public string mail { get; set; }
        public decimal telefono { get; set; }
        public Direccion direccion { get; set; }
        public Rubro rubro { get; set; }
        public string nombreContacto { get; set; }
        public bool habilitado { get; set; }

        public Proveedor(int id, string RazonSocial, string cuit, string mail, decimal telefono, Direccion direccion, Rubro rubro, string nombreContacto, bool habilitado) {

            this.id = id;
            this.RazonSocial = RazonSocial;
            this.cuit = cuit;
            this.mail = mail;
            this.telefono = telefono;
            this.direccion = direccion;
            this.rubro = rubro;
            this.nombreContacto = nombreContacto;
            this.habilitado = habilitado;
        
        }
        
        public override string ToString()
        {
            return RazonSocial;
        }

    }
}
