using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public class MantenimientoDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaMantenimiento { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Costo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Operador { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CabanaId { get; set; }

    }
}
