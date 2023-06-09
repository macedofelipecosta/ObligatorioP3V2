using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Interfaces
{
    public interface IModificacion<T>
    {
        public void Edit(T obj);
     
    }
}
