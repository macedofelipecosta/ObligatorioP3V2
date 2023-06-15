using LogicaNegocio.Excepciones.TipoExcepciones;
using LogicaNegocio.Excepciones.UsuarioException;
using LogicaNegocio.InterfaceDominio;
using LogicaNegocio.ValueObject;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace LogicaNegocio.Entidades
{
    public class Usuario:IValidable
    {

        public string Email { get; set; }
        public Password PassWord { get; set; }
        
        public Usuario()
        {
            
        }

        public void Validate()
        {
            NameValidation();
        }

        public void NameValidation()
        {
            try
            {
                Regex regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");

                if (string.IsNullOrEmpty(this.Email))
                {
                    throw new UsuarioEmailException("No se ha recibido un email!");
                }

                if (!regex.IsMatch(this.Email))
                {
                    throw new UsuarioEmailException("No se ha podido validar el email!");
                }
            }
            catch (UsuarioEmailException e)
            {

                throw new UsuarioEmailException(e.Message);
            }
        }

    }
}

