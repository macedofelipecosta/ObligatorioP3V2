
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
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
            catch (CabanaContextException e) { throw new CabanaLAException(e.Message); }
            catch (CabanaLAException e) { throw new CabanaLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new CabanaLAException(e.Message); }
            catch (TipoContextException e) { throw new CabanaLAException(e.Message); }
            catch (Exception e) { throw new CabanaLAException(e.Message); }

        }
    }
}
