using LogicaNegocio.ValueObject;
using System.Buffers.Text;
using System.Security.Cryptography;

namespace LogicaNegocio.Entidades
{
    public class Usuario
    {

        public string Email { get; set; }
        public Password PassWord { get; set; }
        //public Token Token { get; private set; }
        public Usuario()
        {
            //Token = new Token();
        }



    }
}

