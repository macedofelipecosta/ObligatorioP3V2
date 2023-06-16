using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class GetAll:IGetAll<Mantenimiento>
    {
        private RepositorioMantenimiento _repositorioMantenimiento;

        public GetAll(RepositorioMantenimiento repositorioMantenimiento)
        {
            _repositorioMantenimiento = repositorioMantenimiento;
        }

        public IEnumerable<Mantenimiento> ListarTodos()
        {
            try
            {   
                return _repositorioMantenimiento.GetAll();
            }
            catch (CabanaContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (TipoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoLAException e) { throw new MantenimientoLAException(e.Message); }
            catch (Exception e) { throw new MantenimientoLAException(e.Message); }


        }
    }
}
