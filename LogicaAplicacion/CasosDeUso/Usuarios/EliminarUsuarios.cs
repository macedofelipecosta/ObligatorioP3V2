using LogicaNegocio.Entidades;
using LogicaConexion.EntityFramework;
using LogicaNegocio.Excepciones.UsuarioExceptions;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class EliminarUsuarios
    {
        private RepositorioUsuario _repositorioUsuario;
        public EliminarUsuarios(RepositorioUsuario repositorioUsuario) { _repositorioUsuario = repositorioUsuario; }

        public void EliminarUsuario(Usuario obj)
        {
            try
            {
                _repositorioUsuario.Delete(obj.Email);
            }
            catch (Exception)
            {

                throw new UsuarioDeleteException($"No se ha podido eliminar al usuario: {obj.Email}");
            }
            
        }
    }
}
