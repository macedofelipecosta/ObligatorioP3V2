using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExceptions
{
    public class TipoUpdateException : DomainException
    {
        public TipoUpdateException()
        {
        }

        public TipoUpdateException(string message) : base(message)
        {
        }
    }
}
