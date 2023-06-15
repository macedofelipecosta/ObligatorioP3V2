using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.VOExceptions
{
    public class VONombreException : DomainException
    {
        public VONombreException()
        {
        }

        public VONombreException(string message) : base(message)
        {
        }
    }
}
