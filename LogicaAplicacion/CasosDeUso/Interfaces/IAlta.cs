using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Interfaces
{
    public interface IAlta<T>
    {
        public void Create(T obj);
    }
}
