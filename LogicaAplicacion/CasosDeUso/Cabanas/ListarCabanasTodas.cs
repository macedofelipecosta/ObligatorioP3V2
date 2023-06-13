using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
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
            catch (CabanaContextException e) { throw new CabanaLAException(e.Message); }
            catch (CabanaLAException e) { throw new CabanaLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new CabanaLAException(e.Message); }
            catch (TipoContextException e) { throw new CabanaLAException(e.Message); }
            catch (Exception e) { throw new CabanaLAException(e.Message); }
        }
    }
}
