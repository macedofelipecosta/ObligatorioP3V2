using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.VOExceptions
{
    internal class VOHabCapacityException : DomainException
    {
        public VOHabCapacityException()
        {
        }

        public VOHabCapacityException(string message) : base(message)
        {
        }
    }
}
