using LogicaNegocio.Excepciones.CabanaExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class CapacidadHabitacion
    {
        private int _data;
        public int Data {  get {return _data; } private set { _data = value; } }

        public CapacidadHabitacion(int data)
        {
            ValidarPersonasCabana(data);
            _data = data;
        }
        private void ValidarPersonasCabana(int data)
        {
            try
            {
                if (data <= 0)
                {
                    throw new CabanaHabCapacityException("La capacidad de la habitación debe ser mayor a 0 !");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
