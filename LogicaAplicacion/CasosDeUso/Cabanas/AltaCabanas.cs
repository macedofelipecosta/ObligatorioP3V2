using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.CabanaExceptions;
using System.Linq.Expressions;

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
            catch (CabanaContextException e) { throw new CabanaLAException(e.Message); }
            catch (CabanaLAException e) { throw new CabanaLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new CabanaLAException(e.Message); }
            catch (TipoContextException e) { throw new CabanaLAException(e.Message); }
            catch (Exception e) { throw new CabanaLAException(e.Message); }

        }


    }
}
