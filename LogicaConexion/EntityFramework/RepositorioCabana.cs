using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabanaExcepciones;
using LogicaNegocio.InterfaceRepositorio;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaConexion.EntityFramework
{
    public class RepositorioCabana : IRepositorioCabana
    {
        private HotelContext _hotelContext;
        public RepositorioCabana(HotelContext hotelContext) { _hotelContext = hotelContext; }



        public int UltimoId()
        {
            try
            {
                if (_hotelContext.Cabanas.Count() == 0)
                {
                    return 0;
                }
                int last = _hotelContext.Cabanas.OrderBy(x => x.NumeroHabitacion).LastOrDefault().NumeroHabitacion + 1;
                return last;
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al encontrar ultimo id");
            }
        }

        public void Add(Cabana obj)
        {
            try
            {
                obj.Validate();
                NombreEnUso(obj.Nombre.Data);
                NumeroHabitacionEnUso(obj.NumeroHabitacion);
                _hotelContext.Cabanas.Add(obj);
                _hotelContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public Cabana Get(int numeroHabitacion)
        {
            try
            {
                Cabana cabana = _hotelContext.Cabanas.Where(x => x.NumeroHabitacion == numeroHabitacion).FirstOrDefault();
                return cabana;
            }
            catch (Exception)
            {
                throw new Exception("No se ha encontrado el número de habitación!");
            }


        }

        public Cabana Get(string nombre)
        {

            //To Do: validaciones parse para que este todo en minusculas?, buscar por numero? 

            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception("No se ha recibido ninugún nombre de tipo de cabaña.");
            }
            var cabana = _hotelContext.Cabanas.FirstOrDefault(cabana => cabana.Nombre.Data == nombre);
            if (cabana == null)
            {
                throw new Exception("No se ha encontrado el tipo de cabaña");
            }
            return cabana;
        }

        public IEnumerable<Cabana> GetAll()
        {
            return _hotelContext.Cabanas.ToList();
        }

        public IEnumerable<Cabana> FiltradoNombre(string dato)
        {
            var lista = _hotelContext.Cabanas.Where(item => item.Nombre.Data.Contains(dato)).ToList();
            return lista;
        }
        public IEnumerable<Cabana> FiltradoTipo(string dato)
        {
            var lista = _hotelContext.Cabanas.Where(item => item.NombreTipo.Data.Contains(dato)).ToList();
            return lista;
        }
        public IEnumerable<Cabana> FiltradoNumero(int dato)
        {
            //var  = _hotelContext.Cabanas.Where(item => item.CapacidadHabitacion.Equals(dato)).ToList();
            var lista = _hotelContext.Cabanas.Where(item => item.CapacidadHabitacion.Data >= dato).ToList();
            return lista;
        }
        public IEnumerable<Cabana> AlquilerHabilitado(bool HabilitadoAReservas)
        {
            var lista = _hotelContext.Cabanas.Where(item => item.HabilitadoAReservas.Data == HabilitadoAReservas).ToList();
            return lista;
        }

        private void NombreEnUso(string nombreP)
        {
            try
            {
                var nombre = _hotelContext.Cabanas.Where(x => x.Nombre.Data == nombreP).ToList();
                if (nombre.Count>0) { throw new CabanaNameException("El nombre de ingresado para esta cabaña ya existe en la base de datos!"); }
            }
            catch (CabanaNameException e)
            {
                throw new CabanaNameException(e.Message);
            }
        }
        private void NumeroHabitacionEnUso(int dato)
        {
            try
            {
                var numero = _hotelContext.Cabanas.Where(x => x.NumeroHabitacion == dato).ToList();
                if (numero.Count>0) { throw new Exception("El numero de habitación ingresado ya existe!"); }
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
        }
    }
}
