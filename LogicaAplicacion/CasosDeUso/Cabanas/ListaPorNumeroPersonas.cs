
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabanaExceptions;


namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class ListaPorNumeroPersonas
    {
        private RepositorioCabana _repositorioCabana;
        public ListaPorNumeroPersonas(RepositorioCabana repositorioCabana)
        {
            _repositorioCabana = repositorioCabana;
        }
        public IEnumerable<Cabana> Lista_Filtrada_Numero_Personas(int dato)
        {
            try
            {
                return _repositorioCabana.FiltradoNumero(dato);
            }
            catch (CabanaLAException e)
            {
                throw new CabanaLAException(e.Message);
            }
            

        }
    }
}
