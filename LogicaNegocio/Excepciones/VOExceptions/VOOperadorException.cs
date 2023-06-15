using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.VOExceptions
{
    public class VOOperadorException : DomainException
    {
        public VOOperadorException()
        {
        }

        public VOOperadorException(string message) : base(message)
        {
        }
    }
}
