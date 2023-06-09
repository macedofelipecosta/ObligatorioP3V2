using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaConexion.EntityFramework;
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
            catch (Exception)
            {

                throw new TipoSearchException ("No se ha encontrado ningún tipo de cabaña!");
            }
           
        }
    }
}
