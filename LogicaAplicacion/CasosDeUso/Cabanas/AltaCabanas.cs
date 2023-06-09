using LogicaAplicacion.CasosDeUso.Interfaces;


using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.CabanaExceptions;

namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class AltaCabanas : IAlta<Cabana>
    {

        private RepositorioCabana _repositorioCabana;

        public AltaCabanas(RepositorioCabana repositorioCabana)
        {
            _repositorioCabana = repositorioCabana;
        }

        public void Create(Cabana obj)
        {
            try
            {
                _repositorioCabana.Add(obj);
            }
            catch (Exception e)
            {

                throw new CabanaCreateException (e.Message);
            }

        }


    }
}
