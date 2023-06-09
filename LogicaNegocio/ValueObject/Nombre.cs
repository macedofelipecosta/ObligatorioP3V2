using LogicaNegocio.Excepciones.TipoExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Nombre
    {
        private string _data;
        public string Data { get { return _data; } private set { _data = value; } }

        public Nombre(string data)
        {
            ValidateText(data);
            _data = data;
        }
        public void ValidateText(string data)
        {
            Regex regex = new Regex(@"^[A-Za-zñÑ0-9- ' ]+\s*[A-Za-zñÑ0-9 ' \s-]*[A-Za-zñÑ0-9- ']+$");
            
            if (string.IsNullOrEmpty(data))
            {
                throw new TipoNameException("No se ha recibido un nombre!");
            }

            if (!regex.IsMatch(data))
            {
                throw new TipoNameException("No se ha podido validar el nombre!");
            }
        }
    }
}
