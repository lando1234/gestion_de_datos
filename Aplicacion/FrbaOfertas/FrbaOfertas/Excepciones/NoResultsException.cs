using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Excepciones
{
    public class NoResultsException : ApplicationException
    {
        public NoResultsException(string message)
            : base(message)
        {
        }
    }
}
