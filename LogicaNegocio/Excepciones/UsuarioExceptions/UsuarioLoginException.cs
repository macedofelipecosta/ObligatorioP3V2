using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.UsuarioExceptions
{
    public class UsuarioLoginException : DomainException
    {
        public UsuarioLoginException()
        {
        }

        public UsuarioLoginException(string message) : base(message)
        {
        }
    }
}
