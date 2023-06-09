using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.MantenimientoExceptions
{
    public class MantenimientoDescriptionException : DomainException
    {
        public MantenimientoDescriptionException()
        {
        }

        public MantenimientoDescriptionException(string message) : base(message)
        {
        }
    }
}
