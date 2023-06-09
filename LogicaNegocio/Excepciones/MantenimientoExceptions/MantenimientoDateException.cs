using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.MantenimientoExceptions
{
    public class MantenimientoDateException : DomainException
    {
        public MantenimientoDateException()
        {
        }

        public MantenimientoDateException(string message) : base(message)
        {
        }
    }
}
