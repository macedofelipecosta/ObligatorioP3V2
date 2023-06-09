
using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabanaExceptions;

namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class BuscarNumeroHabitacion
    {
        private RepositorioCabana _repositorioCabana;
        public BuscarNumeroHabitacion(RepositorioCabana repositorioCabana)
        {
            _repositorioCabana = repositorioCabana;
        }
        public Cabana EncontrarNumHab(int numeroHabitacion)
        {
            try
            {
                return _repositorioCabana.Get(numeroHabitacion); ;
            }
            catch (Exception e)
            {
                throw new CabanaSearchException(e.Message);
            }

        }
    }
}
