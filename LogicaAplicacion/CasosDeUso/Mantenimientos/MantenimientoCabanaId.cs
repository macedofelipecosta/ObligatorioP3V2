using LogicaConexion.EntityFramework;
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
            catch (MantenimientoLAException)
            {
                throw new MantenimientoLAException("No se han encontrado mantenimientos para esta cabaña!");
            }
            
        }
    }
}
