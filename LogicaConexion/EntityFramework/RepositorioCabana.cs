using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.HotelException;
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
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }
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
            catch (CabanaContextException e)
            {
                throw new CabanaContextException(e.Message);
            }
            catch (HotelContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error a nivel de Add-Cabana Context!"); }
        }
        public Cabana Get(int numeroHabitacion)
        {
            try
            {
                Cabana cabana = _hotelContext.Cabanas.Where(x => x.NumeroHabitacion == numeroHabitacion).FirstOrDefault();
                if (cabana == null) throw new CabanaContextException($"No se han encontrado cabañas por este número de habitación: {numeroHabitacion}");
                return cabana;
            }
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }
        }

        public Cabana Get(string nombre)
        {

            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    throw new CabanaContextException("No se ha recibido ninugún nombre de tipo de cabaña.");
                }
                var cabana = _hotelContext.Cabanas.FirstOrDefault(cabana => cabana.Nombre.Data == nombre);
                if (cabana == null)
                {
                    throw new CabanaContextException($"No se ha encontrado el tipo de cabaña: {nombre}");
                }
                return cabana;
            }
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }
        }

        public IEnumerable<Cabana> GetAll()
        {
            try
            {
                return _hotelContext.Cabanas.ToList();
            }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }

        }

        public IEnumerable<Cabana> FiltradoNombre(string dato)
        {
            try
            {
                var lista = _hotelContext.Cabanas.Where(item => item.Nombre.Data.Contains(dato)).ToList();
                if (lista.IsNullOrEmpty()) throw new CabanaContextException($"No se ha encontrado ninguna cabaña con el nombrbe: {dato}!");
                return lista;
            }
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }

        }
        public IEnumerable<Cabana> FiltradoTipo(string dato)
        {
            try
            {
                var lista = _hotelContext.Cabanas.Where(item => item.NombreTipo.Data.Contains(dato)).ToList();
                if (lista.IsNullOrEmpty()) throw new CabanaContextException($"No se han encontrado cabañas del tipo: {dato}");
                return lista;
            }
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }

        }
        public IEnumerable<Cabana> FiltradoNumero(int dato)
        {
            try
            {
                var lista = _hotelContext.Cabanas.Where(item => item.CapacidadHabitacion.Data >= dato).ToList();
                if (lista.IsNullOrEmpty()) throw new CabanaContextException($"No se han encontrado cabañas con capacidad en habitación de {dato} personas!");
                return lista;
            }
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }

        }
        public IEnumerable<Cabana> AlquilerHabilitado(bool HabilitadoAReservas)
        {
            try
            {
                var lista = _hotelContext.Cabanas.Where(item => item.HabilitadoAReservas.Data == HabilitadoAReservas).ToList();
                if (lista.IsNullOrEmpty()&&HabilitadoAReservas==true) throw new CabanaContextException($"No se han encontrado cabañas habilitadas a alquilar!");
                if (lista.IsNullOrEmpty() && HabilitadoAReservas == false) throw new CabanaContextException($"No se han encontrado cabañas inhabilitadas a alquilar!");
                return lista;
            }
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }

        }

        private void NombreEnUso(string nombreP)
        {
            try
            {
                var nombre = _hotelContext.Cabanas.Where(x => x.Nombre.Data == nombreP).ToList();                
                if (nombre.Count > 0) { throw new CabanaContextException("El nombre de ingresado para esta cabaña ya existe en la base de datos!"); }
            }
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }

        }
        private void NumeroHabitacionEnUso(int dato)
        {
            try
            {
                var numero = _hotelContext.Cabanas.Where(x => x.NumeroHabitacion == dato).ToList();
                if (numero.Count > 0) { throw new CabanaContextException("El numero de habitación ingresado ya existe!"); }
            }
            catch (CabanaContextException e) { throw new CabanaContextException(e.Message); }
            catch (Exception) { throw new CabanaContextException("Ha ocurrido un error inesperado!"); }
        }
    }
}
