using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;

namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class Ultimo_Id
    {
        private RepositorioCabana _repoCabana;
        public Ultimo_Id(RepositorioCabana repoCabana)
        {
            _repoCabana = repoCabana;
        }

        public int GetLastId()
        {
            try
            {
                return _repoCabana.UltimoId();
            }
            catch (CabanaContextException e) { throw new CabanaLAException(e.Message); }
            catch (CabanaLAException e) { throw new CabanaLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new CabanaLAException(e.Message); }
            catch (TipoContextException e) { throw new CabanaLAException(e.Message); }
            catch (Exception e) { throw new CabanaLAException(e.Message); }

        }
    }
}
