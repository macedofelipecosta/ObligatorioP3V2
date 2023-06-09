using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Interfaces
{
    public interface IGetById<T>
    {
        public T Obtener_Por_Id(int id);
    }
}
