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



        public Cabana() { }

        //public Cabana(string nombre, string descripcion, string nombreTipo, bool jacuzzi,
        //              bool habilitadoAReservas,
        //              int capacidadHabitacion, string fotografia)
        //{
        //    Nombre = new Nombre(nombre);
        //    Descripcion = new Descripcion(descripcion);
        //    NombreTipo = new Nombre(nombreTipo);
        //    Jacuzzi = new Jacuzzi(jacuzzi);
        //    HabilitadoAReservas = new HabilitadaReserva(habilitadoAReservas);
        //    CapacidadHabitacion = new CapacidadHabitacion(capacidadHabitacion);
        //    Fotografia = new Fotografia(fotografia);
        //}

        public void Validate()
        {
          
        }
    }
}
