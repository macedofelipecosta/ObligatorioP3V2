using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.UsuarioException
{
    public class UsuarioPassWordException:DomainException
    {
        public UsuarioPassWordException() { }

        public UsuarioPassWordException(string message) : base(message)
        {
        }
    }
}
