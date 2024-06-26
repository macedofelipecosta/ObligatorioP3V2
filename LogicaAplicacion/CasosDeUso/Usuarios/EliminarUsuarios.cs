﻿using LogicaNegocio.Entidades;
using LogicaConexion.EntityFramework;

using LogicaAplicacion.Excepciones.UsuarioExceptions;
using LogicaConexion.Excepciones.UsuarioExceptions;
using LogicaAplicacion.CasosDeUso.Interfaces;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class EliminarUsuarios:IDelete<Usuario>
    {
        private RepositorioUsuario _repositorioUsuario;
        public EliminarUsuarios(RepositorioUsuario repositorioUsuario) { _repositorioUsuario = repositorioUsuario; }

        public void DelteObj(Usuario obj)
        {
            try
            {
                _repositorioUsuario.Delete(obj.Email);
            }
            catch (UsuarioContextException e) { throw new UsuarioLAException(e.Message); }
            catch (Exception e) { throw new UsuarioLAException(e.Message); };
        }
    }
}
