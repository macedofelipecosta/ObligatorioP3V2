using LogicaConexion.Excepciones.UsuarioExceptions;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfaceRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaConexion.EntityFramework
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private HotelContext _hotelContext;
        public RepositorioUsuario(HotelContext hotelContext) { _hotelContext = hotelContext; }

        public void Add(Usuario obj)
        {
            //validaciones usuario?
            _hotelContext.Usuarios.Add(obj);
            _hotelContext.SaveChanges();
        }

        public void Delete(string email)
        {
            var usuario = Get(email);
            _hotelContext.Usuarios.Remove(usuario);
            _hotelContext.SaveChanges();

        }

        public Usuario Get(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new UsuarioContextException("No se ha recibido email");
            }

            var usuario = _hotelContext.Usuarios.FirstOrDefault(x => x.Email == email);
            if (usuario == null)
            {
                throw new UsuarioContextException("No se ha encontrado el email.");
            }
            return usuario;

        }

        public IEnumerable<Usuario> GetAll()
        {
            return _hotelContext.Usuarios.ToList();
        }

        public void Update(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new UsuarioContextException("No se ha recibido un usuario.");
            }
            try
            {
                var usuario = Get(email);
                _hotelContext.Usuarios.Update(usuario);
                _hotelContext.SaveChanges();
            }
            catch (UsuarioContextException)
            {

                throw new UsuarioContextException("Ha ocurrido un error al actualizar el usuario.");
            }
        }
    }
}
