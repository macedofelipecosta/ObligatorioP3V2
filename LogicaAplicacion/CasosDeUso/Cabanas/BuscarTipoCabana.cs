
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
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
            catch (CabanaContextException e) { throw new CabanaLAException(e.Message); }
            catch (CabanaLAException e) { throw new CabanaLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new CabanaLAException(e.Message); }
            catch (TipoContextException e) { throw new CabanaLAException(e.Message); }
            catch (Exception e) { throw new CabanaLAException(e.Message); }

        }
    }
}
