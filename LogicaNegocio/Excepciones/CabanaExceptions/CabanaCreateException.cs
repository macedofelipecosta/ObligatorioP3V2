using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabanaExceptions
{
    public class CabanaCreateException: DomainException
    {
        public CabanaCreateException(string message) : base(message) { }
        public CabanaCreateException() { }
    }
}
