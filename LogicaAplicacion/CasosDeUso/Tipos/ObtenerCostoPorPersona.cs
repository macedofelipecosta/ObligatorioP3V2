using LogicaAplicacion.Excepciones.TipoExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExcepciones;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class ObtenerCostoPorPersona
    {
        private RepositorioTipo _repositorioTipo;
        public ObtenerCostoPorPersona(RepositorioTipo reposiitorioTipo)
        {
            _repositorioTipo = reposiitorioTipo;
        }
        public int GetCostoPersona(Tipo obj)
        {
            try
            {
                return _repositorioTipo.CostoPersona(obj.Nombre);
            }
            catch (CabanaContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoContextException e) { throw new TipoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoLAException e) { throw new TipoLAException(e.Message); }
            catch (Exception e) { throw new TipoLAException(e.Message); }

        }
    }
}
