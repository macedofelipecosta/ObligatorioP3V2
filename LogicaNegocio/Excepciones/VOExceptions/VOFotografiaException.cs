using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.VOExceptions
{
    internal class VOFotografiaException : DomainException
    {
        public VOFotografiaException()
        {
        }

        public VOFotografiaException(string message) : base(message)
        {
        }
    }
}
