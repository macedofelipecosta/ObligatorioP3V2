using LogicaConexion.EntityFramework;
using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExceptions;
using LogicaAplicacion.Excepciones.TipoExcepciones;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaNegocio.ValueObject;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class EliminarTipos:IDelete<Tipo>
    {
        private RepositorioTipo _repositorioTipo;

        public EliminarTipos(RepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }

        public void DelteObj(Tipo obj)
        {
            try
            {
                _repositorioTipo.Delete(obj.Nombre);
            }
            catch (CabanaContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoContextException e) { throw new TipoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoLAException e) { throw new TipoLAException(e.Message); }
            catch (Exception e) { throw new TipoLAException(e.Message); }
        }
    }
}
