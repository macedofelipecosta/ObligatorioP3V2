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
            catch (MantenimientoContextException)
            {

                throw new MantenimientoContextException("No se ha podido guardar el mantenimiento!");
            }

        }

        public IEnumerable<Mantenimiento> GetAll()
        {
            return _hotelContext.Mantenimientos.ToList();
        }

        public int UltimoId()
        {
            if (_hotelContext.Mantenimientos.IsNullOrEmpty())
            {
                return 0;
            }
            int last = _hotelContext.Mantenimientos.OrderBy(x => x.Id).LastOrDefault().Id + 1;
            return last;
        }

        public IEnumerable<Mantenimiento> GetForCabanaId(int numeroHabitacion)
        {
            var mantenimientos = _hotelContext.Mantenimientos.Where(
                x => x.Cabana.NumeroHabitacion == numeroHabitacion).ToList();
            return mantenimientos;
        }

    }
}
