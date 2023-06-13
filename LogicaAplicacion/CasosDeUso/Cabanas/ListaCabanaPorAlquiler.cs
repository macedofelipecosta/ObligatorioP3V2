
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabanaExceptions;


namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class ListaCabanaPorAlquiler
    {
        private RepositorioCabana _repositorioCabana;
        public ListaCabanaPorAlquiler(RepositorioCabana repositorioCabana)
        {
            _repositorioCabana = repositorioCabana;
        }

        public IEnumerable<Cabana> Lista_Filtrada_Alquiler(bool HabilitadoAReservas)
        {
            try
            {                
                return _repositorioCabana.AlquilerHabilitado(HabilitadoAReservas);
            }
            catch (CabanaLAException e)
            {

                throw new CabanaLAException(e.Message);
            }
            
        }
    }
}
