using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExceptions
{
    public class TipoSearchException : DomainException
    {
        public TipoSearchException()
        {
        }

        public TipoSearchException(string message) : base(message)
        {
        }
    }
}
