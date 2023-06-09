using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfaceRepositorio
{
    public interface IRepositorio<T>
    {
        public void Add(T obj);
        //public void Update(T obj);
        //public void Delete(T obj);
        //public T Get(int id);
        public IEnumerable<T> GetAll();
    }
}
