using LogicaAplicacion.CasosDeUso.Cabanas;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class MantenimientoEntreCostos
    {
        private RepositorioMantenimiento _repo;
        private GetAll _getAll;
        private BuscarNumeroHabitacion _numHab;

        public MantenimientoEntreCostos(RepositorioMantenimiento repo, GetAll getAll, BuscarNumeroHabitacion numHab)
        {

            _repo = repo;
            _getAll = getAll;
            _numHab = numHab;
        }

        public IEnumerable<Mantenimiento> EntreCostos(int valor1, int valor2)
        {
            try
            {
                var list = _getAll.ListarTodos();
                foreach (var item in list) { item.Cabana = _numHab.Obtener_Por_Id(item.CabanaId); }
                var aux = list.Where(x=>x.Cabana.CapacidadHabitacion.Data>=valor1 && x.Cabana.CapacidadHabitacion.Data <= valor2).ToList();

                return aux;
            }
            catch (MantenimientoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (Exception e) { throw new MantenimientoLAException(e.Message); }
        }


    }
}
