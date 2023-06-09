


using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabanaExceptions;


namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class ListarCabanaPorTipo
    {
        private RepositorioCabana _repositorioCabana;
        public ListarCabanaPorTipo(RepositorioCabana repositorioCabana)
        {
            _repositorioCabana = repositorioCabana;
        }
        public IEnumerable<Cabana> Lista_Filtrada_Tipo(string dato)
        {
            try
            {
                return _repositorioCabana.FiltradoTipo(dato);
            }
            catch (Exception e)
            {

                throw new CabanaSearchException(e.Message);
            }

            

        }
    }
}
