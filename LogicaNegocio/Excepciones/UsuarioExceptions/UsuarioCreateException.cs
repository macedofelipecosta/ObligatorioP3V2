using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.UsuarioExceptions
{
    public class UsuarioCreateException : DomainException
    {
        public UsuarioCreateException()
        {
        }

        public UsuarioCreateException(string message) : base(message)
        {
        }
    }
}
