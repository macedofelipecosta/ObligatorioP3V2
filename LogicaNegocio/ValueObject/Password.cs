using LogicaNegocio.Excepciones.UsuarioException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Password
    {
        private string _data;
        public string Data { get { return _data; } private set { _data = value; } }

        public Password(string data)
        {
            ValidarPassWord(data);
            _data = data;
        }

        private void ValidarPassWord(string data)
        {
            try
            {
                string patron = @"^(?=.*[a-zñ])(?=.*[A-ZÑ])(?=.*\d)(?=.*[@$!%*?&])[A-Za-zñÑ\d@$!%*?&]{6,}$";
                Match coincide = Regex.Match(data, patron);
                if (!coincide.Success)
                {
                    throw new UsuarioPassWordException("La contraseña no es válida!");
                }
            }
            catch (UsuarioPassWordException e)
            {
                throw new UsuarioPassWordException(e.Message);
            }
        }

    }
}
