using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaConexion.Excepciones.HotelException
{
    internal class HotelContextException : DomainException
    {
        public HotelContextException()
        {
        }

        public HotelContextException(string message) : base(message)
        {
        }

    }
}
