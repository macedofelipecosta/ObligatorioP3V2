using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfaceRepositorio
{
    public interface IRepositorioCabana:IRepositorio<Cabana>
    {
        public void Get(string nombre) { }
        public void Update(int id) { }
        public void Delete(string nombre) { }

    }
}
