using AutoMapper;
using LogicaAplicacion.CasosDeUso.Cabanas;
using LogicaAplicacion.CasosDeUso.Mantenimientos;
using LogicaAplicacion.Excepciones.CabanaExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Runtime.Serialization;
using WebApi.DTOs;
using WebApi.Excepciones.MantenimientoExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/Mantenimientos")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        private IMapper _mapper;
        private AltaMantenimiento _altaMantenimiento;
        private BuscarNumeroHabitacion _buscarCabana;
        private GetAll _getAll;
        private GetBetweenDates _getBetweenDates;
        private MantenimientoCabanaId _mantCabanaId;
        private VerificarMantenimiento _verificar;
        private MantenimientoEntreCostos _entreCostos;

        public MantenimientosController(IMapper mapper, AltaMantenimiento altaMantenimiento, BuscarNumeroHabitacion buscarCabana,
                                        GetAll getAll, GetBetweenDates getBetweenDates, MantenimientoCabanaId mantCabanaId, VerificarMantenimiento verificar
                                        , MantenimientoEntreCostos entreCostos)
        {
            _mapper = mapper;
            _altaMantenimiento = altaMantenimiento;
            _buscarCabana = buscarCabana;
            _getAll = getAll;
            _getBetweenDates = getBetweenDates;
            _mantCabanaId = mantCabanaId;
            _verificar = verificar;
            _entreCostos = entreCostos;
        }



        // GET: api/<MantenimientosController>
        /// <summary>
        /// devuelve todos los mantenimientos registrados
        /// </summary>
        /// <returns>devuelve una lista con todos los mantenimientos</returns>
        [HttpGet("~/Mantenimientos/GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAll()
        {
            try
            {
                List<MantenimientoDTO> list = _mapper.Map<List<MantenimientoDTO>>(_getAll.Listar_todos());

                if (list.IsNullOrEmpty()) throw new MantenimientoSearchException($"No se han encontrado mantenimientos!");
                return Ok(list);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (MantenimientoLAException e) { return BadRequest(e.Message); }
            catch (MantenimientoSearchException e) { return NotFound(e.Message); }
            catch (MantenimientoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET api/<MantenimientosController>/5
        /// <summary>
        /// filtra y devuelve los mantenimientos dados para determinado numero de habitacion
        /// </summary>
        /// <param name="cabanaId"></param>
        /// <returns>devuelve los mantenimientos realizados para determinado numero de habitacion</returns>
        [HttpGet("~/Mantenimientos/MantenimientosCabana")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get(int cabanaId)
        {
            try
            {
                List<MantenimientoDTO> list = _mapper.Map<List<MantenimientoDTO>>(_mantCabanaId.MantenimientoXidCabana(cabanaId));
                if (list.IsNullOrEmpty()) throw new MantenimientoSearchException($"No se han encontrado mantenimientos para este id {cabanaId}");
                return Ok(list);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (MantenimientoLAException e) { return BadRequest(e.Message); }
            catch (MantenimientoSearchException e) { return NotFound(e.Message); }
            catch (MantenimientoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }

        }


        //GET api/<MantenimientosController>/5

        /// <summary>
        /// filtra entre todos los mantenimientos los que se encuentren dentro del rangos de las fechas y contengan
        /// ese numero de habitacion
        /// </summary>
        /// <param DateTime="fecha1"></param>
        /// <param DateTime="fecha2"></param>
        /// <param Numero_Habitación="numeroHabitacion"></param>
        /// <returns>devuelve los mantenimientos realizados para determinado numero de habitacion y determinado 
        /// rango de fechas
        /// </returns>
        [HttpGet("~/Mantenimientos/MantenimientosEntreFechas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult MantenimientoEntreFechas(string fecha1, string fecha2, int NumeroHabitacion)
        {
            try
            {
                DateTime f1 = DateTime.Parse(fecha1);
                DateTime f2 = DateTime.Parse(fecha2);
                if (f1 > f2)
                {
                    throw new MantenimientoControllerException("La primer fecha no puede ser mayor a la segunda fecha!");
                }

                var aux = _getBetweenDates.MantenimientoPorFechas(f1, f2, NumeroHabitacion);
                if (aux.IsNullOrEmpty())
                {
                    throw new MantenimientoSearchException($"No se han encontrado mantenimientos entre las fechas {f1.ToShortDateString()} " +
                        $"- {f2.ToShortDateString} y la habitación número {NumeroHabitacion}");
                }
                List<MantenimientoDTO> list = _mapper.Map<List<MantenimientoDTO>>(aux);
                return Ok(list);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (MantenimientoLAException e) { return BadRequest(e.Message); }
            catch (MantenimientoSearchException e) { return NotFound(e.Message); }
            catch (MantenimientoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor1"></param>
        /// <param name="valor2"></param>
        /// <returns>devuelve los mantenimientos entre los costos proporcionados, agrupados por nombre operador
        /// y la suma de los costos de sus mantenimientos</returns>
        [HttpGet("~/Mantenimientos/EntreCostos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult MantenimientoPorCostos(int valor1, int valor2)
        {
            try
            {
                var aux = _entreCostos.EntreCostos(valor1, valor2);
                List<MantenimientoDTO> list = _mapper.Map<List<MantenimientoDTO>>(aux);
                var aux2 = list.GroupBy(M => M.Operador)
                                .Select(group => new
                                {
                                    Operador = group.Key,
                                    Costo = group.Sum(M => M.Costo)
                                })
                                .ToList();
                if (aux2.Count == 0) throw new MantenimientoControllerException("No se han encontrado mantenimientos");
                return Ok(aux2);
            }
            catch (MantenimientoControllerException e) { return NotFound(e.Message); }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (Exception) { return BadRequest("Hubo un error inesperado"); }
        }

        // POST api/<MantenimientosController>
        /// <summary>
        ///  crea un nuevo objeto mantenimiento a partir del objetoDTO mantenimiento
        /// </summary>
        /// <param name="objDto"></param>
        /// <param name="cabanaId"></param>
        /// <returns>Devuelve el objeto DTO creado</returns>
        [HttpPost("~/Mantenimientos/AltaMantenimiento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post(MantenimientoDTO objDto)
        {

            try
            {
                if (objDto == null) throw new MantenimientoControllerException("Debe proporcionar un mantenimiento para ser dado de alta!");

                Mantenimiento mantenimiento = _mapper.Map<Mantenimiento>(objDto);

                Cabana cabana = _buscarCabana.EncontrarNumHab(objDto.CabanaId);
                if (cabana == null) throw new MantenimientoSearchException("No se han encontrado cabañas con ese numero de habitación!");

                _verificar.VerificarMantenimientos(objDto.CabanaId, objDto.FechaMantenimiento);
                mantenimiento.Cabana = cabana;

                _altaMantenimiento.NuevoMantenimiento(mantenimiento);
                return Created($"Se ha anadido el mantenimiento a la cabana {cabana.Nombre.Data}", objDto);
            }
            catch (CabanaLAException e) { return BadRequest(e.Message); }
            catch (MantenimientoLAException e) { return BadRequest(e.Message); }
            catch (MantenimientoSearchException e) { return NotFound(e.Message); }
            catch (MantenimientoControllerException e) { return BadRequest(e.Message); }
            catch (Exception e) { return BadRequest(e.Message); }

        }





    }
}
