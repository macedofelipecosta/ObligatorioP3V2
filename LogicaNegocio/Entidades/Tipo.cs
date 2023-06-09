using LogicaNegocio.Excepciones.TipoExcepciones;
using LogicaNegocio.InterfaceDominio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Tipo
    {
        
        public string Nombre { get; set; }
        public Descripcion Descripcion { get; set; }
        public Costo CostoHuesped { get; set; }

        public Tipo() { }

        

    }
}
