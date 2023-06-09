using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.UsuarioExceptions
{
    public class UsuarioDeleteException : DomainException
    {
        public UsuarioDeleteException()
        {
        }

        public UsuarioDeleteException(string message) : base(message)
        {
        }
    }
}
