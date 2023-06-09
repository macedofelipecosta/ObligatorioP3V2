using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabanaExcepciones
{
    public class CabanaDescriptionException : DomainException
    {
        public CabanaDescriptionException(){}

        public CabanaDescriptionException(string message) : base(message){}
    }
}
