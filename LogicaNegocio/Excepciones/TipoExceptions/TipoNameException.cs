using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoExcepciones
{
    public class TipoNameException:DomainException
    {
        public TipoNameException() { }
        public TipoNameException(string message) : base(message) { }

    }
}
