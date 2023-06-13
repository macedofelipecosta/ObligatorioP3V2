using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Excepciones.UsuarioException
{
    public class UsuarioControllerException:DomainException
    {
        public UsuarioControllerException() { }

        public UsuarioControllerException(string message) : base(message)
        {
        }
    }
}
