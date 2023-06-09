using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class HabilitadaReserva
    {
        private bool _data;
        public bool Data { get { return _data; } private set { _data = value; } }

        public HabilitadaReserva(bool data)
        {
            _data = data;
        }
    }
}
