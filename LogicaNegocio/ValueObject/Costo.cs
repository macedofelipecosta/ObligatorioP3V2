using LogicaNegocio.Excepciones.MantenimientoExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Costo
    {
        private int _data;
        public int Data { get { return _data; } private set { _data = value; } }

        public Costo(int data)
        {
            ValidarCosto(data);
            _data = data;
        }

        private void ValidarCosto(int data)
        {
            try
            {
                if (data < 0)
                {
                    throw new MantenimientoCostException("El costo no puede ser menor a cero!");
                }
            }
            catch (MantenimientoCostException e)
            {
                throw e;
            }

        }

    }
}
