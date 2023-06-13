
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabanaExceptions;


namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class BuscarTipoCabana
    {
        private RepositorioCabana _repositorioCabana;
        public BuscarTipoCabana(RepositorioCabana repositorioCabana)
        {
            this._repositorioCabana = repositorioCabana;
        }
        public Cabana EncontrarTipo(string nombre)
        {

            try
            {
                return _repositorioCabana.Get(nombre);
            }
            catch (CabanaLAException e)
            {

                throw new CabanaLAException(e.Message);
            }
            
        }
    }
}
