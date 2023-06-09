using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.UsuarioExceptions;

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
            catch (Exception)
            {

                throw new UsuarioCreateException("No se ha podido crear el usuario!");
            }
            
        }





    }
}
