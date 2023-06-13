using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaConexion.Excepciones.TipoExcepciones
{
    public class TipoContextException:DomainException
    {
        public TipoContextException() { }
        public TipoContextException(string message):base(message) { }
    }
}
