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
                string patron = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$";
                Match coincide = Regex.Match(data, patron);
                if (!coincide.Success)
                {
                    throw new Exception("La contraseña no es válida!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
