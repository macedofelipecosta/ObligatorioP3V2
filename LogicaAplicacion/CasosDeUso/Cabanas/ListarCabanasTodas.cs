using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaAplicacion.Excepciones.CabanaExcepciones;
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
            catch (CabanaLAException e)
            {

                throw new CabanaLAException(e.Message);
            }
        }
    }
}
