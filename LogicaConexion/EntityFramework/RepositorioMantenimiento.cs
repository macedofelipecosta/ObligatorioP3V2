using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfaceRepositorio;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaConexion.EntityFramework
{
    public class RepositorioMantenimiento : IRepositorioMantenimiento
    {
        private HotelContext _hotelContext;
        public RepositorioMantenimiento(HotelContext hotelContext) { _hotelContext = hotelContext; }

        public void Add(Mantenimiento obj)
        {
            try
            {
                _hotelContext.Mantenimientos.Add(obj);
                _hotelContext.SaveChanges();
            }
            catch (MantenimientoContextException e) { throw new MantenimientoContextException(e.Message); }
            catch (Exception) { throw new MantenimientoContextException("Ha ocurrido un error inesperado!"); }

        }

        public IEnumerable<Mantenimiento> GetAll()
        {
            try
            {
                return _hotelContext.Mantenimientos.ToList();
            }
            catch (MantenimientoContextException e) { throw new MantenimientoContextException(e.Message); }
            catch (Exception) { throw new MantenimientoContextException("Ha ocurrido un error inesperado!"); }

        }

        public int UltimoId()
        {
            try
            {
                if (_hotelContext.Mantenimientos.IsNullOrEmpty())
                {
                    return 0;
                }
                int last = _hotelContext.Mantenimientos.OrderBy(x => x.Id).LastOrDefault().Id + 1;
                return last;
            }
            catch (MantenimientoContextException e) { throw new MantenimientoContextException(e.Message); }
            catch (Exception) { throw new MantenimientoContextException("Ha ocurrido un error inesperado!"); }

        }

        public IEnumerable<Mantenimiento> GetForCabanaId(int numeroHabitacion)
        {
            try
            {
                var mantenimientos = _hotelContext.Mantenimientos.Where(
                                x => x.Cabana.NumeroHabitacion == numeroHabitacion).ToList();
                if (mantenimientos.IsNullOrEmpty()) throw new MantenimientoContextException($"No se han encontrado mantenimientos para este número de habitación {numeroHabitacion}!");
                return mantenimientos;
            }
            catch (MantenimientoContextException e) { throw new MantenimientoContextException(e.Message); }
            catch (Exception) { throw new MantenimientoContextException("Ha ocurrido un error inesperado!"); }

        }

    }
}
