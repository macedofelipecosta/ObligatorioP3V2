﻿using LogicaAplicacion.Excepciones.UsuarioExceptions;
using LogicaConexion.EntityFramework;
using LogicaConexion.Excepciones.UsuarioExceptions;
using LogicaNegocio.Entidades;


namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class InicioSesion
    {
        private RepositorioUsuario _repositorioUsuario;

        public InicioSesion(RepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public bool IniciarSesion(Usuario obj)
        {
            try
            {
                if (obj == null) throw new UsuarioLAException("No se ha podido iniciar sesión, compruebe que los campos no estén vacíos!");

                var usuario = _repositorioUsuario.Get(obj.Email);

                if (usuario.Email == obj.Email && usuario.PassWord.Data == obj.PassWord.Data)
                {
                    return true;
                }
                else {throw new UsuarioLAException("Usuario o contraseña incorrectos!");}
            }
            catch (UsuarioContextException e) { throw new UsuarioLAException(e.Message); }
            catch (UsuarioLAException e) { throw new UsuarioLAException(e.Message); }
            catch (Exception e) { throw new UsuarioLAException(e.Message); };


        }


    }
}
