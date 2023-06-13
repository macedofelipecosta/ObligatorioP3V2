using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Excepciones.MantenimientoExceptions;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class GetLastId
    {
        private RepositorioMantenimiento _repositorioMantenimiento;

        public GetLastId(RepositorioMantenimiento repositorioMantenimiento)
        {
            _repositorioMantenimiento = repositorioMantenimiento;
        }

        public int GetLastIdMant()
        {
            try
            {
                return _repositorioMantenimiento.UltimoId();
            }
            catch (CabanaContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (TipoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoLAException e) { throw new MantenimientoLAException(e.Message); }
            catch (Exception e) { throw new MantenimientoLAException(e.Message); }

        }
    }
}
