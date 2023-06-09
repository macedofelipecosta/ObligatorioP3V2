using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Interfaces
{
    public interface IGetAll<T>
    {
        public IEnumerable<T> ListarTodos();
    }
}
