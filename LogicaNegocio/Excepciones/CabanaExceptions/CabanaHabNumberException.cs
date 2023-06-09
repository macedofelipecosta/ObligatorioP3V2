using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabanaExcepciones
{
    public class CabanaHabNumberException : DomainException
    {
        public CabanaHabNumberException()
        {
        }

        public CabanaHabNumberException(string message) : base(message)
        {
        }
    }
}
