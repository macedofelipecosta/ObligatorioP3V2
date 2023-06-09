﻿using LogicaConexion.EntityFramework;
using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExceptions;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class EliminarTipos
    {
        private RepositorioTipo _repositorioTipo;

        public EliminarTipos(RepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }

        public void DelteObj(string nombre)
        {
            try
            {
                _repositorioTipo.Delete(nombre);
            }
            catch (TipoDeleteException)
            {

                throw new TipoDeleteException ("No se ha podido eliminar este tipo de cabaña!");
            }
        }

       



    }
}