using AutoMapper;
using LogicaAplicacion.CasosDeUso.Tipos;
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaAplicacion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using LogicaNegocio.Excepciones.TipoExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using WebApi.DTOs;
using WebApi.Excepciones.MantenimientoExceptions;
using WebApi.Excepciones.TipoExcepciones;
using WebApi.Excepciones.TipoExceptions;

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
        /// devuelve todos los tipos de cabanas registrados
        /// </summary>
        /// <returns>devuelve una lista con todos los tipos de cabanas registrados</returns>
        [HttpGet("~/Tipos/GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (TipoLAException e) { return BadRequest(e.Message); }
            catch (TipoSearchException e) { return NotFound(e.Message); }
            catch (TipoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET api/<TiposController>/5
        /// <summary>
        /// filtra entre todos los tipos de cabana registrados el parametro ingresado en el metodo
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>devuelve una lista de tipos de cabana </returns>
        [HttpGet("~/Tipos/GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (TipoLAException e) { return BadRequest(e.Message); }
            catch (TipoSearchException e) { return NotFound(e.Message); }
            catch (TipoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // POST api/<TiposController>
        /// <summary>
        /// Crea un nuevo tipo de cabana y devuelve el objeto DTO con su informacion
        /// </summary>
        /// <param name="objDto"></param>
        /// <returns>Crea un nuevo tipo de cabana y devuelve el objeto DTO con su informacion</returns>
        [HttpPost("~/Tipos/Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Tipo> Post(TipoDTO objDto)
        {
            try
            {
                if (objDto == null) throw new TipoControllerException("No se ha recibido ningún tipo de cabaña para registrar! ");
                Tipo tipo = _mapper.Map<Tipo>(objDto);
                _altaTipo.Create(tipo);
                return Created($"El tipo de cabana {tipo.Nombre} ha sido creado correctamente", objDto);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (TipoLAException e) { return BadRequest(e.Message); }
            catch (TipoSearchException e) { return NotFound(e.Message); }
            catch (TipoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }

        }

        // PUT api/<TiposController>/5
        /// <summary>
        /// busca entre los tipos de cabanas registrados por el nombre ingresado, si lo obtiene se cambia la descripcion y
        /// costoHuesped originales por los ingresados por parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="costoHuesped"></param>
        /// <returns>deveulve un mensaje de que se ha modificado con exito incluyendo el nombre del tipo modificado</returns>
        [HttpPut("~/Tipos/Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Tipo> Put(string nombre, string descripcion, int costoHuesped)
        {
            try
            {
                if (nombre == null || descripcion == null || costoHuesped <= 0) throw new TipoControllerException("Hay un error en los datos ingresados!");
                _modificarTipos.Edit(nombre,descripcion,costoHuesped);
                return Ok($"El tipo de cabaña {nombre} se ha actualizado correctamente!");

            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (TipoLAException e) { return BadRequest(e.Message); }
            catch (TipoSearchException e) { return NotFound(e.Message); }
            catch (TipoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }

        }

        // DELETE api/<TiposController>/5
        /// <summary>
        /// busca el nombre ingresado entre los tipos de cabana registrados y al encontrarlo lo elimina
        /// </summary>
        /// <param name="nombre"></param>
        [HttpDelete("~/Tipos/EliminarTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Tipo> Delete(string nombre)
        {
            try
            {
                _eliminarTipos.DelteObj(nombre);

                return Ok($"Se ha eliminado el tipo de cabaña {nombre} correctamente!");
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (TipoLAException e) { return BadRequest(e.Message); }
            catch (TipoSearchException e) { return NotFound(e.Message); }
            catch (TipoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}
