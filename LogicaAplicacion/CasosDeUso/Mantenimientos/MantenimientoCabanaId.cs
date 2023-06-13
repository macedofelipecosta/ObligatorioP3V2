using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class MantenimientoCabanaId
    {
        private RepositorioMantenimiento _repositorioMantenimiento;

        public MantenimientoCabanaId(RepositorioMantenimiento repositorioMantenimiento)
        {
            _repositorioMantenimiento = repositorioMantenimiento;
        }

        public IEnumerable<Mantenimiento> MantenimientoXidCabana(int numeroHabitacion)
        {
            try
            {
                return _repositorioMantenimiento.GetForCabanaId(numeroHabitacion);
            }
            catch (CabanaContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (TipoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoLAException e) { throw new MantenimientoLAException(e.Message); }
            catch (Exception e) { throw new MantenimientoLAException(e.Message); }

        }
    }
}
