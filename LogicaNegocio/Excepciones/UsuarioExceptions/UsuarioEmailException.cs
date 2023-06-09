using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.UsuarioException
{
    public class UsuarioEmailException : DomainException
    {
        public UsuarioEmailException() { }
        public UsuarioEmailException(string message) : base(message)
        {
        }
    }
}
