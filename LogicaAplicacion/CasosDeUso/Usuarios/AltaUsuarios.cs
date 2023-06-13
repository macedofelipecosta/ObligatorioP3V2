using LogicaAplicacion.Excepciones.UsuarioExceptions;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.UsuarioExceptions;
using LogicaNegocio.Entidades;


namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class AltaUsuarios
    {
        private RepositorioUsuario _repositorioUsuario;

        public AltaUsuarios(RepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void CrearUsuario(Usuario obj)
        {

            try
            {
                _repositorioUsuario.Add(obj);

            }
            catch (UsuarioContextException e) { throw new UsuarioLAException(e.Message); }
            catch (Exception e) { throw new UsuarioLAException(e.Message); };
            
        }





    }
}
