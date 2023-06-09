using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabanaExcepciones
{
    public class CabanaJacuzziException : DomainException
    {
        public CabanaJacuzziException()
        {
        }

        public CabanaJacuzziException(string message) : base(message)
        {
        }

    }
}
