
using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.CabanaExceptions;


namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class ListaCabanaPorNombre
    {
        private RepositorioCabana _repositorioCabana;
        public ListaCabanaPorNombre(RepositorioCabana repositorioCabana) { _repositorioCabana = repositorioCabana; }

        public IEnumerable<Cabana> Lista_Filtrada_Nombre(string dato)
        {
            try
            {
                return _repositorioCabana.FiltradoNombre(dato);
            }
            catch (Exception e)
            {

                throw new CabanaSearchException(e.Message);
            }



        }
    }
}
