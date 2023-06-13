using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaConexion.Excepciones.UsuarioExceptions
{
    public class UsuarioContextException : DomainException
    {
        public UsuarioContextException()
        {
        }

        public UsuarioContextException(string message) : base(message)
        {
        }
    }
}
