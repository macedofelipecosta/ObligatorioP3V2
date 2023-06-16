using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaAplicacion.Excepciones.TipoExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using LogicaNegocio.Excepciones.TipoExceptions;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class EncontrarTipo
    {
        private RepositorioTipo _repositorioTipo;

        public EncontrarTipo(RepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }

        public Tipo Encontrar_Tipo(string nombre)
        {
            try
            {

                return _repositorioTipo.Get(nombre);
            }
            catch (CabanaContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoContextException e) { throw new TipoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new TipoLAException(e.Message); }
            catch (TipoLAException e) { throw new TipoLAException(e.Message); }
            catch (Exception e) { throw new TipoLAException(e.Message); }

        }

        
    }
}
