using LogicaAplicacion.CasosDeUso.Interfaces;

using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabanaExceptions;


namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class ListarCabanasTodas : IGetAll<Cabana>
    {
        private RepositorioCabana _repositorioCabana;
        public ListarCabanasTodas(RepositorioCabana repositorioCabana)
        {
            _repositorioCabana = repositorioCabana;
        }


        public IEnumerable<Cabana> ListarTodos()
        {
            try
            {
                return _repositorioCabana.GetAll();
            }
            catch (Exception e)
            {

                throw new CabanaSearchException(e.Message);
            }
        }
    }
}
