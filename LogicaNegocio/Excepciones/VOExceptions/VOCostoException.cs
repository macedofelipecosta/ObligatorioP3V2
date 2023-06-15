using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.VOExceptions
{
    internal class VOCostoException : DomainException
    {
        public VOCostoException()
        {
        }

        public VOCostoException(string message) : base(message)
        {
        }
    }
}
