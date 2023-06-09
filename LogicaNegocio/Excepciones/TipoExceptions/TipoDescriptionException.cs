using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExcepciones
{
    public class TipoDescriptionException :DomainException
    {
        public TipoDescriptionException() { }
        public TipoDescriptionException(string message) :base(message) { }

    }
}
