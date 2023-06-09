using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class AltaMantenimiento
    {
        private RepositorioMantenimiento _repoMantenimiento;
        public AltaMantenimiento(RepositorioMantenimiento repoMantenimiento)
        {
            _repoMantenimiento = repoMantenimiento;
        }

        public void NuevoMantenimiento(Mantenimiento obj)
        {
            try
            {
                _repoMantenimiento.Add(obj);
            }
            catch (MantenimientoCreateException)
            {
                throw new MantenimientoCreateException ($"No se ha podido agregar este mantenimiento: {obj.Id}!");
            }


        }
    }
}
