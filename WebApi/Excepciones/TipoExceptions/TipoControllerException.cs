using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Excepciones.TipoExcepciones
{
    public class TipoControllerException:DomainException
    {
        public TipoControllerException() { }
        public TipoControllerException(string message):base(message) { }
    }
}
