using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Excepciones.CabanaExcepciones
{
    public class CabanaControllerException : DomainException
    {
        public CabanaControllerException()
        {
        }

        public CabanaControllerException(string message) : base(message)
        {
        }

    }
}
