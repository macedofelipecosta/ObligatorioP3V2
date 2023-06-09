using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Operador
    {
        private string _data;
        public string Data { get { return _data; } private set { _data = value; } }

        public Operador(string data)
        {
            ValidarOperador(data);
            _data = data;
        }
        private void ValidarOperador(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    throw new Exception("El mantenimiento debe tener un operador!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
