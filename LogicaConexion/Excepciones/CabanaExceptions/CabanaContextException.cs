using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaConexion.Excepciones.CabanaExcepciones
{
    public class CabanaContextException : DomainException
    {
        public CabanaContextException()
        {
        }

        public CabanaContextException(string message) : base(message)
        {
        }
    }
}
