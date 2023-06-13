﻿using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.MantenimientoExceptions
{
    public class MantenimientoLAException : DomainException
    {
        public MantenimientoLAException()
        {
        }

        public MantenimientoLAException(string message) : base(message)
        {
        }
    }
}
