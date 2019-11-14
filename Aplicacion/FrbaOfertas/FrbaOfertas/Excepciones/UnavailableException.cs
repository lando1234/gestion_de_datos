using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Excepciones
{
    public class UnavailableException : ApplicationException
    {
        public UnavailableException(string message)
            : base(message)
        {
        }
    }
}
