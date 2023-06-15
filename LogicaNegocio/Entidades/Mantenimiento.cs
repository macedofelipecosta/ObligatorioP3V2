using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using LogicaNegocio.InterfaceDominio;
using LogicaNegocio.ValueObject;

namespace LogicaNegocio.Entidades
{
    public class Mantenimiento : IValidable
    {

        public int Id { get; set; }
        public DateTime FechaMantenimiento { get; set; }
        public Descripcion Descripcion { get; set; }
        public Costo Costo { get; set; }
        public Operador Operador { get; set; }
        public Cabana Cabana { get; set; }

        public void Validate()
        {
            ValidarFecha();
        }

        public Mantenimiento()
        {
            
        }



        private void ValidarFecha()
        {
            try
            {
                if (this.FechaMantenimiento.Date > DateTime.Today.Date)
                {
                    throw new MantenimientoDateException("La fecha no puede ser futura!");
                }
            }
            catch (MantenimientoDateException e)
            {
                throw e;
            }
            catch (Exception) { throw new MantenimientoDateException("Ha ocurrido un error inesperado!"); }
        }

    }
}
