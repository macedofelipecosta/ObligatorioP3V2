using AutoMapper;
using LogicaAplicacion.CasosDeUso.Tipos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private AltaTipos _altaTipo;
        private EliminarTipos _eliminarTipos;
        private EncontrarTipo _encontrarTipo;
        private ListarPorNombre _listarPorNombre;
        private ListarTiposTodos _listarTiposTodos;
        private ModificarTipos _modificarTipos;
        private ObtenerCostoPorPersona _obtenerCostoPorPersona;
        private IMapper _mapper;

        public TiposController(AltaTipos altaTipo, EliminarTipos eliminarTipos, EncontrarTipo encontrarTipo,
                               ListarPorNombre listarPorNombre, ListarTiposTodos listarTiposTodos, ModificarTipos modificarTipos,
                               ObtenerCostoPorPersona obtenerCostoPorPersona, IMapper mapper)
        {
            _altaTipo = altaTipo;
            _eliminarTipos = eliminarTipos;
            _encontrarTipo = encontrarTipo;
            _listarPorNombre = listarPorNombre;
            _listarTiposTodos = listarTiposTodos;
            _modificarTipos = modificarTipos;
            _obtenerCostoPorPersona = obtenerCostoPorPersona;
            _mapper = mapper;
        }




        // GET: api/<TiposController>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/Tipos/GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAll()
        {
            try
            {
                List<TipoDTO> list = _mapper.Map<List<TipoDTO>>(_listarTiposTodos.ListarTodos());
                if (list.IsNullOrEmpty()) throw new TipoSearchException("No se han encontrado tipos de cabaña para mostrar");
                return Ok(list);
            }
            catch (TipoSearchException e)
            {

                return BadRequest(e.Message);
            }
        }

        // GET api/<TiposController>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        [HttpGet("~/Tipos/GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetByName(string dato)
        {
            try
            {
                List<TipoDTO> list = _mapper.Map<List<TipoDTO>>(_listarPorNombre.ListaFiltradaPorNombre(dato));
                if (list.IsNullOrEmpty()) throw new TipoSearchException("No se han encontrado tipos de cabaña para mostrar");
                return Ok(list);
            }
            catch (TipoSearchException e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<TiposController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDto"></param>
        /// <returns></returns>
        [HttpPost("~/Tipos/Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Tipo> Post(TipoDTO objDto)
        {
            try
            {
                Tipo tipo = _mapper.Map<Tipo>(objDto);
                _altaTipo.Create(tipo);
                return Ok($"El tipo de cabaña {tipo.Nombre} ha sido creado correctamente");
            }
            catch (TipoCreateException e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT api/<TiposController>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="costoHuesped"></param>
        /// <returns></returns>
        [HttpPut("~/Tipos/Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Tipo> Put(string nombre, string descripcion, int costoHuesped)
        {
            try
            {          
                _modificarTipos.Edit(nombre,descripcion,costoHuesped);
                return Ok($"El tipo de cabaña {nombre} se ha actualizado correctamente!");

            }
            catch (TipoUpdateException e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE api/<TiposController>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        [HttpDelete("~/Tipos/EliminarTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Tipo> Delete(string nombre)
        {
            try
            {
                _eliminarTipos.DelteObj(nombre);
                return Ok($"Se ha eliminado el tipo de cabaña {nombre} correctamente!");
            }
            catch (TipoDeleteException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
