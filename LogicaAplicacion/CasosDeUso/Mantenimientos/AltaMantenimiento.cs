using LogicaAplicacion.CasosDeUso.Cabanas;
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class AltaMantenimiento
    {
        private RepositorioMantenimiento _repoMantenimiento;
        private BuscarNumeroHabitacion _repoCabana;
        public AltaMantenimiento(RepositorioMantenimiento repoMantenimiento, BuscarNumeroHabitacion repoCabana)
        {
            _repoMantenimiento = repoMantenimiento;
            _repoCabana = repoCabana;
        }

        public void NuevoMantenimiento(Mantenimiento obj)
        {
            try
            {
                var cabana=_repoCabana.Obtener_Por_Id(obj.CabanaId);
                obj.Cabana = cabana;
                _repoMantenimiento.Add(obj);
            }
            catch (CabanaContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (TipoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoLAException e) { throw new MantenimientoLAException(e.Message); }
            catch (Exception e) { throw new MantenimientoLAException(e.Message); }


        }
    }
}
