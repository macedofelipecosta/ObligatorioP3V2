using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabanaExceptions
{
    public class CabanaSearchException : DomainException
    {
        public CabanaSearchException()
        {
        }

        public CabanaSearchException(string message) : base(message)
        {
        }

    }
}
