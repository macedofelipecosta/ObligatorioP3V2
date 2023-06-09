using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.MantenimientoExceptions
{
    public class MantenimientoCreateException:DomainException
    {
        public MantenimientoCreateException()
        {
        }

        public MantenimientoCreateException(string message) : base(message)
        {
        }
    }
}
