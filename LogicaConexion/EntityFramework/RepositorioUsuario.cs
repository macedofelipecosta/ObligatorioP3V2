using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaConexion.Excepciones.UsuarioExceptions;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.UsuarioException;
using LogicaNegocio.InterfaceRepositorio;
using Microsoft.IdentityModel.Tokens;

namespace LogicaConexion.EntityFramework
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private HotelContext _hotelContext;
        public RepositorioUsuario(HotelContext hotelContext) { _hotelContext = hotelContext; }

        public void Add(Usuario obj)
        {
            try
            {
                obj.Validate();
                _hotelContext.Usuarios.Add(obj);
                _hotelContext.SaveChanges();
            }
            catch (UsuarioPassWordException e) { throw new UsuarioContextException(e.Message); }
            catch (UsuarioEmailException e) { throw new UsuarioContextException(e.Message); }
            catch (UsuarioContextException e) { throw new UsuarioContextException(e.Message); }
            catch (Exception) { throw new UsuarioContextException("Ha ocurrido un error inesperado!"); }

        }

        public void Delete(string email)
        {
            try
            {
                var usuario = Get(email);
                _hotelContext.Usuarios.Remove(usuario);
                _hotelContext.SaveChanges();
            }
            catch (UsuarioContextException e) { throw new UsuarioContextException(e.Message); }
            catch (Exception) { throw new UsuarioContextException("Ha ocurrido un error inesperado!"); }


        }

        public Usuario Get(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) throw new UsuarioContextException("No se ha recibido email");
                var usuario = _hotelContext.Usuarios.FirstOrDefault(x => x.Email == email);
                if (usuario == null) throw new UsuarioContextException($"No se ha encontrado el email: {email}");
                
                return usuario;
            }
            catch (UsuarioContextException e) { throw new UsuarioContextException(e.Message); }
            catch (Exception) { throw new UsuarioContextException("Ha ocurrido un error inesperado!"); }

        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                var list=_hotelContext.Usuarios.ToList();
                if (list.IsNullOrEmpty()) throw new UsuarioContextException("No se han encontrado usuarios registrados!");
                return list;
            }
            catch (UsuarioContextException e) { throw new UsuarioContextException(e.Message); }
            catch (Exception) { throw new UsuarioContextException("Ha ocurrido un error inesperado!"); }

        }

        public void Update(string email)
        {
            try
            {
                var usuario = Get(email);
                _hotelContext.Usuarios.Update(usuario);
                _hotelContext.SaveChanges();
            }
            catch (UsuarioContextException e) { throw new UsuarioContextException(e.Message); }
            catch (Exception) { throw new UsuarioContextException("Ha ocurrido un error inesperado!"); }
        }
    }
}
