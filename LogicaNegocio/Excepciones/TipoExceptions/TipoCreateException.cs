using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExceptions
{
    public class TipoCreateException : DomainException
    {
        public TipoCreateException()
        {
        }

        public TipoCreateException(string message) : base(message)
        {
        }
    }
}
