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
        ListarTiposTodos _getAll;
        public ObtenerCostoPorPersona(RepositorioTipo reposiitorioTipo, ListarTiposTodos getAll)
        {
            _repositorioTipo = reposiitorioTipo;
            _getAll = getAll;
        }
        public IEnumerable<Tipo> FiltrarCosto(int costo)
        {
            try
            {
                var tipos = _getAll.ListarTodos();
                var lista = tipos.Where(x => x.CostoHuesped.Data >= 0 && x.CostoHuesped.Data < costo).ToList();
                return lista;
                
            }
            catch (CabanaContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoContextException e) { throw new TipoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoLAException e) { throw new TipoLAException(e.Message); }
            catch (Exception e) { throw new TipoLAException(e.Message); }

        }
    }
}
