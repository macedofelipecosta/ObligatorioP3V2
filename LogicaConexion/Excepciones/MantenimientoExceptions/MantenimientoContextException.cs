using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaConexion.Excepciones.MantenimientoExceptions
{
    public class MantenimientoContextException : DomainException
    {
        public MantenimientoContextException()
        {
        }

        public MantenimientoContextException(string message) : base(message)
        {
        }
    }
}
