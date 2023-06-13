using LogicaConexion.Excepciones.CabanaExcepciones;
using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
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
                    throw new MantenimientoLAException("No se pueden realizar mas de 3 mantenimientos por día!");
                }
                if (fechaMantenimiento.Date > DateTime.Today.Date)
                {
                    throw new MantenimientoLAException("La fecha debe ser anterior al día de hoy!");
                }
            }
            catch (CabanaContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (TipoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoContextException e) { throw new MantenimientoLAException(e.Message); }
            catch (MantenimientoLAException e) { throw new MantenimientoLAException(e.Message); }
            catch (Exception e) { throw new MantenimientoLAException(e.Message); }
        }

    }
}
