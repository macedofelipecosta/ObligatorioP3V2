using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfaceRepositorio
{
    public interface IRepositorioTipo:IRepositorio<Tipo>
    {

        public void Get(string nombre) { }
        public void Update(string nombre) { }
        public void Delete(string nombre) { }
    }
}
