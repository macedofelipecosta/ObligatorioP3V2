using LogicaAplicacion.Excepciones.TipoExcepciones;
using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExceptions;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class ListarPorNombre
    {
        private RepositorioTipo _repositorioTipo;
        public ListarPorNombre(RepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }
        
        
        public IEnumerable<Tipo> ListaFiltradaPorNombre(string palabra)
        {
            try
            {
                return _repositorioTipo.GetTipoByString(palabra);
            }
            catch (TipoLAException)
            {

                throw new TipoLAException($"No se han encontrado tipos de cabaña con el nombre: {palabra}");
            }
         
        }
    }
}
