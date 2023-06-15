using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public class CabanaDTO
    {
        public int NumeroHabitacion {  get; set; }
        ///<summary></summary>
        ///
        public string Nombre { get; set; }
        ///<summary></summary>
        ///
        public string Descripcion { get; set; }
        ///<summary></summary>
        ///
        public string NombreTipo { get; set; }
        ///<summary></summary>
        ///
        public bool Jacuzzi { get; set; }
        ///<summary></summary>
        ///
        public bool HabilitadoAReservas { get; set; }
        ///<summary></summary>
        ///
        public int CapacidadHabitacion { get; set; }
        ///<summary></summary>
        ///
        public string Fotografia { get; set; } = "Sin Fotografía.jpg";
    }
}
