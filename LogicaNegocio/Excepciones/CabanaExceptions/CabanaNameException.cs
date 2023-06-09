using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabanaExcepciones
{
    public class CabanaNameException:DomainException
    {

        public CabanaNameException() { }
        public CabanaNameException(string message) : base(message) { }

    }
}
