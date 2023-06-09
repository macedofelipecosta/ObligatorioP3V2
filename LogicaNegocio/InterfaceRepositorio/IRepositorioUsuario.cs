using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfaceRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public void Get(string email) { }
        public void Update(string email) { }
        public void Delete(string email) { }
    }
}
