using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExceptions
{
    public class TipoDeleteException : DomainException
    {
        public TipoDeleteException()
        {
        }

        public TipoDeleteException(string message) : base(message)
        {
        }
    }
}
