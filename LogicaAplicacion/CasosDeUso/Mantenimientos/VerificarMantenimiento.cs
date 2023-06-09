using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Mantenimientos
{
    public class VerificarMantenimiento
    {
        private MantenimientoCabanaId _mantenimiento;
        public VerificarMantenimiento(MantenimientoCabanaId mantenimiento) {
            _mantenimiento = mantenimiento;
        }

        public void VerificarMantenimientos(int numeroHabitacion, DateTime fechaMantenimiento)
        {
            try
            {
                var lista = _mantenimiento.MantenimientoXidCabana(numeroHabitacion);
                var aux = lista.Where(x => x.FechaMantenimiento.Date == fechaMantenimiento.Date).ToList();
                if (aux.Count >= 3)
                {
                    throw new MantenimientoDateException("No se pueden realizar mas de 3 mantenimientos por día!");
                }
                if (fechaMantenimiento.Date > DateTime.Today.Date)
                {
                    throw new MantenimientoDateException("La fecha debe ser anterior al día de hoy!");
                }
            }
            catch (MantenimientoDateException e)
            {

                throw new MantenimientoDateException(e.Message);
            }
        }

    }
}
