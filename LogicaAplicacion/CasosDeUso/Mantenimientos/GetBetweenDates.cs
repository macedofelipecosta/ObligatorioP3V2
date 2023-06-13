using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using Microsoft.IdentityModel.Tokens;

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
                if (aux.IsNullOrEmpty()) throw new MantenimientoLAException($"No se han obtenido mantenimientos entre las fechas {fecha1} y {fecha2} para el número de habitación {numeroHabitacion}! ");
                return aux;
            }
            catch (CabanaContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (TipoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoLAException e) { throw new MantenimientoLAException(e.Message); }
            catch (Exception e) { throw new MantenimientoLAException(e.Message); }

        }


    }
}
