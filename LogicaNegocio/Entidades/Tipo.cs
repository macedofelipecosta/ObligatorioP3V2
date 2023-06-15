using LogicaNegocio.Excepciones.TipoExcepciones;
using LogicaNegocio.Excepciones.VOExceptions;
using LogicaNegocio.InterfaceDominio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.Entidades
{
    public class Tipo : IValidable
    {

        public string Nombre { get; set; }
        public Descripcion Descripcion { get; set; }
        public Costo CostoHuesped { get; set; }

        public Tipo() { }

        public void Validate()
        {
            NameValidation();
        }

        public void NameValidation()
        {
            try
            {
                Regex regex = new Regex(@"^(?! )[A-Za-z ]+(?<! )$");

                if (string.IsNullOrEmpty(this.Nombre))
                {
                    throw new TipoNameException("No se ha recibido un nombre!");
                }

                if (!regex.IsMatch(this.Nombre))
                {
                    throw new TipoNameException("No se ha podido validar el nombre!");
                }
            }
            catch (TipoNameException e)
            {

                throw new TipoNameException(e.Message);
            }
        }
    }
}
