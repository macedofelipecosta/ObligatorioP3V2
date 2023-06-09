using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabanaExcepciones
{
    public class CabanaBookingException : DomainException
    {
        public CabanaBookingException()
        {
        }

        public CabanaBookingException(string message) : base(message)
        {
        }
    }
}
