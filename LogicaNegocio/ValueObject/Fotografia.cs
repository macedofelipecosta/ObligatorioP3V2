using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Fotografia
    {
        private string _data;
        public string Data { get { return _data; } private set { _data = value; } }

        public Fotografia(string data)
        {
            _data = data;
        }
    }
}
