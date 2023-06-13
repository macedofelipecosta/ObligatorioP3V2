using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.CabanaExcepciones
{
    public class CabanaLAException : DomainException
    {
        public CabanaLAException()
        {
        }

        public CabanaLAException(string message) : base(message)
        {
        }
    }
}
