using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaAplicacion.Excepciones.CabanaExcepciones;
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
            catch (CabanaLAException e)
            {

                throw new CabanaLAException(e.Message);
            }

        }


    }
}
