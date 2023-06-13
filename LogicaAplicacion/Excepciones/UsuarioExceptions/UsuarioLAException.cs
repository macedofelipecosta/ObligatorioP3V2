using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.UsuarioExceptions
{
    public class UsuarioLAException : DomainException
    {
        public UsuarioLAException()
        {
        }

        public UsuarioLAException(string message) : base(message)
        {
        }
    }
}
