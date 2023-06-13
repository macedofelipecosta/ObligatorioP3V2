using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class GetBetweenDates
    {
        private RepositorioMantenimiento _repositorioMantenimiento;
        private MantenimientoCabanaId _mantenimientoXid;

        public GetBetweenDates(RepositorioMantenimiento repositorioMantenimiento, MantenimientoCabanaId mantenimientoXid)
        {
            _repositorioMantenimiento = repositorioMantenimiento;
            _mantenimientoXid = mantenimientoXid;
        }

        public IEnumerable<Mantenimiento> MantenimientoPorFechas(DateTime fecha1, DateTime fecha2, int numeroHabitacion)
        {
            try
            {
                var list = _mantenimientoXid.MantenimientoXidCabana(numeroHabitacion).OrderByDescending(x => x.Costo);
                var aux = list.Where(x => x.FechaMantenimiento.Date >= fecha1.Date && x.FechaMantenimiento.Date <= fecha2.Date)
                    .OrderByDescending(x => x.Costo).
                    ToList();
                return aux;
            }
            catch (MantenimientoLAException e)
            {
                throw new MantenimientoLAException(e.Message);
            }
        }


    }
}
