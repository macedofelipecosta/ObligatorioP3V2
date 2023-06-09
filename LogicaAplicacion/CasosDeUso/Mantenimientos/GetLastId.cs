using LogicaConexion.EntityFramework;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class GetLastId
    {
        private RepositorioMantenimiento _repositorioMantenimiento;

        public GetLastId(RepositorioMantenimiento repositorioMantenimiento)
        {
            _repositorioMantenimiento = repositorioMantenimiento;
        }

        public int GetLastIdMant()
        {
            return _repositorioMantenimiento.UltimoId();
        }
    }
}
