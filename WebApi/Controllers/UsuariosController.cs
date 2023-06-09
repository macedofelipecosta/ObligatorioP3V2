using AutoMapper;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.UsuarioExceptions;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.JWT;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private AltaUsuarios _altaUsuario;
        private EliminarUsuarios _eliminarUsuario;
        private InicioSesion _inicioSesion;
        private IMapper _mapper;
        private JWToken _jwt;

        public UsuariosController(AltaUsuarios altaUsuario, EliminarUsuarios eliminarUsuario, InicioSesion inicioSesion, IMapper mapper, JWToken jwt)
        {
            _altaUsuario = altaUsuario;
            _eliminarUsuario = eliminarUsuario;
            _inicioSesion = inicioSesion;
            _mapper = mapper;
            _jwt = jwt;
        }



        // GET: api/<UsuariosController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDto"></param>
        /// <returns>Devuelve un jwToken para ser utilizado en las futuras solicitudes, el token caduca a los 60 minutos</returns>
        [HttpPost("~/Usuarios/IniciarSesion")]
        public ActionResult IniciarSesion(UsuarioDTO objDto)
        {
            try { 
                string jwtPass;

            Usuario usuario = _mapper.Map<Usuario>(objDto);
            if (_inicioSesion.IniciarSesion(usuario))
            {
                jwtPass = _jwt.GenerarTokenJWT(usuario.Email);
                return Ok(jwtPass);
            }
                return BadRequest(new UsuarioLoginException("Hubo un problema al iniciar sesión!"));
            }
            catch (UsuarioLoginException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
