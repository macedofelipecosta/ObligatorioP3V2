using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Excepciones.MantenimientoExceptions
{
    public class MantenimientoControllerException : DomainException
    {
        public MantenimientoControllerException()
        {
        }

        public MantenimientoControllerException(string message) : base(message)
        {
        }
    }
}
