using LogicaNegocio.InterfaceDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.CabanaExcepciones;
using System.Globalization;
using System.Linq.Expressions;
using LogicaNegocio.ValueObject;

namespace LogicaNegocio.Entidades
{
    public class Cabana : IValidable
    {

        public int NumeroHabitacion { get; set; }
        public Nombre Nombre { get; set; }
        public Descripcion Descripcion { get; set; }
        public Nombre NombreTipo { get; set; }
        public Jacuzzi Jacuzzi { get; set; }
        public HabilitadaReserva HabilitadoAReservas { get; set; }
        public CapacidadHabitacion CapacidadHabitacion { get; set; }
        public Fotografia Fotografia { get; set; }



        public Cabana()
        {
            
        }



        public void Validate()
        {
            HabNumberValidation(this.NumeroHabitacion);
        }

        private void HabNumberValidation(int data)
        {
            try
            {
                if (data < 0) throw new CabanaHabNumberException("El numero de habitacion no puede ser menor a cero!");
            }
            catch (CabanaHabNumberException e)
            {

                throw new CabanaHabNumberException(e.Message);
            }

        }
    }
}
