using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaAplicacion.Excepciones.TipoExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExceptions;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class ListarTiposTodos:IGetAll<Tipo>
    {
        private RepositorioTipo _repositorioTipo;
        public ListarTiposTodos(RepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }


       public  IEnumerable<Tipo> ListarTodos()
        {
            try
            {
                return _repositorioTipo.GetAll();
            }
            catch (CabanaContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoContextException e) { throw new TipoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoLAException e) { throw new TipoLAException(e.Message); }
            catch (Exception e) { throw new TipoLAException(e.Message); }

        }
    }
}
