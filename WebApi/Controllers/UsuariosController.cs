using AutoMapper;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.Excepciones.UsuarioExceptions;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using WebApi.DTOs;
using WebApi.Excepciones.UsuarioException;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public HttpResponseMessage IniciarSesion(UsuarioDTO objDto)
        {
            try
            {
                string jwtToken;
                HttpResponseMessage response;
                Usuario usuario = _mapper.Map<Usuario>(objDto);
                if (_inicioSesion.IniciarSesion(usuario))
                {
                    jwtToken = _jwt.GenerarTokenJWT(usuario.Email);

                    // Crea una instancia de HttpResponseMessage con el código de estado OK
                    response = new HttpResponseMessage(HttpStatusCode.OK);

                    // Agrega el token JWT al cuerpo de la respuesta
                    response.Content = new StringContent(jwtToken);
                    response.Headers.Add("Authorization", jwtToken);
                    return response;

                }
                else throw new UsuarioControllerException("Usuario o contraseña incorrectos!");

            }
            catch (UsuarioLAException e)
            {
                // Si las credenciales son inválidas, devuelve una respuesta HTTP Unauthorized
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                response.Content = new StringContent("Usuario o contraseña inválidos!");
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");

                return response;
            }
            catch (UsuarioControllerException e)
            {
                // Si se produce una excepción desconocida, devuelve una respuesta HTTP BadRequest
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(e.Message);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");

                return response;
            }
            catch (Exception e)
            {
                // Si se produce una excepción desconocida, devuelve una respuesta HTTP Internal Server Error
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(e.Message);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");

                return response;
            }



        }

    }
}
