using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.TipoExcepciones
{
    public class TipoLAException:DomainException
    {
        public TipoLAException() { }
        public TipoLAException(string message):base(message) { }
    }
}
