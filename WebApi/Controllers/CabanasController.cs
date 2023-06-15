using LogicaAplicacion.CasosDeUso.Cabanas;
using WebApi.DTOs;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using WebApi.Excepciones.CabanaExcepciones;
using LogicaAplicacion.Excepciones.CabanaExcepciones;

using WebApi.Excepciones.CabanaExceptions;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/Cabanas")]
    [ApiController]
    
    public class CabanasController : ControllerBase
    {
        private AltaCabanas _altaCabanas;
        private Ultimo_Id _ultimoId;
        private BuscarNumeroHabitacion _buscarNumeroHabitacion;
        private BuscarTipoCabana _buscarTipoCabana;
        private ListaCabanaPorAlquiler _listaCabanaPorAlquiler;
        private ListaCabanaPorNombre _listaCabanaPorNombre;
        private ListaPorNumeroPersonas _listaPorNumeroPersonas;
        private ListarCabanaPorTipo _listarCabanaPorTipo;
        private ListarCabanasTodas _listarCabanasTodas;
        private IWebHostEnvironment _environment;
        private IMapper _mapper;


        public CabanasController(AltaCabanas altaCabanas,
                                        BuscarNumeroHabitacion buscarNumeroHabitacion,
                                        BuscarTipoCabana buscarTipoCabana,
                                        ListaCabanaPorAlquiler listaCabanaPorAlquiler,
                                        ListaCabanaPorNombre listaCabanaPorNombre,
                                        ListaPorNumeroPersonas listaPorNumeroPersonas,
                                        ListarCabanaPorTipo listarCabanaPorTipo,
                                        ListarCabanasTodas listarCabanasTodas,
                                        IWebHostEnvironment environment,
                                        Ultimo_Id ultimoId,
                                        IMapper mapper
                                        )
        {
            _altaCabanas = altaCabanas;
            _buscarNumeroHabitacion = buscarNumeroHabitacion;
            _buscarTipoCabana = buscarTipoCabana;
            _listaCabanaPorAlquiler = listaCabanaPorAlquiler;
            _listaCabanaPorNombre = listaCabanaPorNombre;
            _listaPorNumeroPersonas = listaPorNumeroPersonas;
            _listarCabanaPorTipo = listarCabanaPorTipo;
            _listarCabanasTodas = listarCabanasTodas;
            _environment = environment;
            _ultimoId = ultimoId;
            _mapper = mapper;
        }

        // GET: api/v1/<CabanasController>
        /// <summary>
        /// Retorna todas las cabañas registradas
        /// </summary>
        /// <returns>Una lista con todas las cabañas, </returns>
        [HttpGet("~/GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                List<CabanaDTO> list = _mapper.Map<List<CabanaDTO>>(_listarCabanasTodas.ListarTodos());

                if (list.IsNullOrEmpty()) throw new CabanaSearchException("No se han encontrado cabañas registradas!");

                return Ok(list);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (CabanaSearchException e) { return NotFound(e.Message); }
            catch (CabanaControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET api/v1/<CabanasController>/5
        /// <summary>
        /// Filtra y devuelve una cabaña por su numero de cabana
        /// </summary>
        /// <param name="id">Identificador de la cabaña</param>
        /// <returns>Devuelve la cabaña con ese número de autos, si no lo encuentra null</returns>
        [HttpGet("~/Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get(int id)
        {
            try
            {
                CabanaDTO cabanaDto = _mapper.Map<CabanaDTO>(_buscarNumeroHabitacion.EncontrarNumHab(id));
                if (cabanaDto == null) { throw new CabanaSearchException($"No se han encontrado cabañas con el número de habitación {id}!"); }
                return Ok(cabanaDto);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (CabanaSearchException e) { return NotFound(e.Message); }
            catch (CabanaControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }

        }

        // POST api/<CabanasController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDto"></param>
        /// <returns>Devuelve un mensaje de que la cabaña se ha creado con éxito</returns>
        [HttpPost("~/CrearCabana")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Cabana> Post(CabanaDTO objDto)
        {
            try
            {
                if (objDto == null) throw new CabanaControllerException("Debe proporcionar una cabaña para dar de alta");
                Cabana cabana = _mapper.Map<Cabana>(objDto);
                _altaCabanas.Create(cabana);
                return Created($"Se ha creado la cabana {objDto.Nombre} con exito!", objDto);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (CabanaSearchException e) { return NotFound(e.Message); }
            catch (CabanaControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns>devuelve una lista de cabañas que fue filtrada por nombre o caracteres</returns>
        [HttpGet("~/BuscarNombre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BuscarNombre(string Nombre)
        {
            try
            {
                if (Nombre != null)
                {
                    var resultado = _listaCabanaPorNombre.Lista_Filtrada_Nombre(Nombre);
                    if (resultado.IsNullOrEmpty())throw new CabanaSearchException($"No se ha encontrado la cabaña :{Nombre}! ");
                    
                    List<CabanaDTO> list = _mapper.Map<List<CabanaDTO>>(resultado);
                    return Ok(list);
                }
                else throw new CabanaControllerException("No se ha recibido ningún nombre para buscar!");
                
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (CabanaSearchException e) { return NotFound(e.Message); }
            catch (CabanaControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NombreTipo"></param>
        /// <returns>Devuelve una lista de cabañas filtradas por su tipo</returns>
        [HttpGet("~/BuscarTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BuscarTipo(string NombreTipo)
        {
            try
            {
                if (NombreTipo != null)
                {
                    var resultado = _listarCabanaPorTipo.Lista_Filtrada_Tipo(NombreTipo);
                    if (resultado.IsNullOrEmpty())
                    {
                        throw new CabanaSearchException($"No se han encontrado cabañas del tipo:{NombreTipo}!");
                    }
                    List<CabanaDTO> list = _mapper.Map<List<CabanaDTO>>(resultado);
                    return Ok(list);
                }
                else { throw new CabanaControllerException("No se ha recibido ningún tipo de cabaña para buscar!"); }
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (CabanaSearchException e) { return NotFound(e.Message); }
            catch (CabanaControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumeroPersonas"></param>
        /// <returns>Devuelve una lista de cabañas filtradas por su capacidad de ocupantes</returns>
        [HttpGet("~/BuscarNumeroPersonas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BuscarNumeroPersonas(int NumeroPersonas)
        {
            try
            {
                if (NumeroPersonas > 0)
                {
                    var resultado = _listaPorNumeroPersonas.Lista_Filtrada_Numero_Personas(NumeroPersonas);
                    if (resultado.IsNullOrEmpty()) throw new CabanaSearchException($"No se han encontrado cabañas con capacidad de {NumeroPersonas} personas!");
                    List<CabanaDTO> list = _mapper.Map<List<CabanaDTO>>(resultado);
                    return Ok(list);
                }
                else { throw new CabanaControllerException("No se ha recibido un numero de huespedes correcto!"); }
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (CabanaSearchException e) { return NotFound(e.Message); }
            catch (CabanaControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HabilitadoAReservas"></param>
        /// <returns>Devuelve una lista de cabañas filtrada por si estan habilitadas para alquilar o no</returns>
        [HttpGet("~/AlquilerHabilitado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AlquilerHabilitado(bool HabilitadoAReservas)
        {
            try
            {
                var resultado = _listaCabanaPorAlquiler.Lista_Filtrada_Alquiler(HabilitadoAReservas);
                if (resultado.IsNullOrEmpty())
                {
                    throw new CabanaSearchException($"No se han encontrado cabañas con alquiler habilitado!");
                }
                List<CabanaDTO> list = _mapper.Map<List<CabanaDTO>>(resultado);
                return Ok( list);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (CabanaSearchException e) { return NotFound("No se han encontrado cabanas"); }
            catch (CabanaControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }

        }
    }
}
