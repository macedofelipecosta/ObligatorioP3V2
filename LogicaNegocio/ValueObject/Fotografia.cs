using LogicaNegocio.Excepciones.VOExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Fotografia
    {
        private string _data;
        public string Data { get { return _data; } private set { _data = value; } }

        public Fotografia(string data)
        {
            ValidateText(data);
            _data = data;
        }

        public void ValidateText(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    throw new VOFotografiaException("No se ha recibido un nombre!");
                }
            }
            catch (VOFotografiaException e)
            {

                throw e;
            }

        }



    }
}
