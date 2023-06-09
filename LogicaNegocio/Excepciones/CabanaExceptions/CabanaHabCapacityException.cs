using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.CabanaExcepciones
{
    public class CabanaHabCapacityException:Exception
    {
        public CabanaHabCapacityException(string message) : base(message) { }
        public CabanaHabCapacityException() { }

    }
}
