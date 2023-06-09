using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class GetAll
    {
        private RepositorioMantenimiento _repositorioMantenimiento;

        public GetAll(RepositorioMantenimiento repositorioMantenimiento)
        {
            _repositorioMantenimiento = repositorioMantenimiento;
        }

        public IEnumerable<Mantenimiento> Listar_todos()
        {
            try
            {
                
                return _repositorioMantenimiento.GetAll();
            }
            catch (MantenimientoSearchException)
            {

                throw new MantenimientoSearchException("No se ha encontrado ningún mantenimiento!");
            }

        }
    }
}
