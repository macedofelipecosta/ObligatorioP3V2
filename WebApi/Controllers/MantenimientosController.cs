using AutoMapper;
using LogicaAplicacion.CasosDeUso.Cabanas;
using LogicaAplicacion.CasosDeUso.Mantenimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.MantenimientoExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
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

        public MantenimientosController(IMapper mapper, AltaMantenimiento altaMantenimiento, BuscarNumeroHabitacion buscarCabana,
                                        GetAll getAll, GetBetweenDates getBetweenDates, MantenimientoCabanaId mantCabanaId,VerificarMantenimiento verificar )
        {
            _mapper = mapper;
            _altaMantenimiento = altaMantenimiento;
            _buscarCabana = buscarCabana;
            _getAll = getAll;
            _getBetweenDates = getBetweenDates;
            _mantCabanaId = mantCabanaId;
            _verificar = verificar;
            
        }



        // GET: api/<MantenimientosController>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/Mantenimientos/GetAll")]
        public ActionResult GetAll()
        {
            try
            {
                List<MantenimientoDTO> list = _mapper.Map<List<MantenimientoDTO>>(_getAll.Listar_todos());

                if (list.IsNullOrEmpty()) throw new MantenimientoSearchException($"No se han encontrado mantenimientos!");
                return Ok(list);
            }
            catch (MantenimientoSearchException e)
            {

                return BadRequest(e.Message);
            }
        }

        // GET api/<MantenimientosController>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cabanaId"></param>
        /// <returns></returns>
        [HttpGet("~/Mantenimientos/MantenimientosCabana")]
        public ActionResult Get(int cabanaId)
        {
            try
            {
                List<MantenimientoDTO> list = _mapper.Map<List<MantenimientoDTO>>(_mantCabanaId.MantenimientoXidCabana(cabanaId));
                if (list.IsNullOrEmpty()) throw new MantenimientoSearchException($"No se han encontrado mantenimientos para este id {cabanaId}");
                return Ok(list);
            }
            catch (MantenimientoSearchException e)
            {
                return BadRequest(e.Message);
            }

        }


        //GET api/<MantenimientosController>/5

        /// <summary>
        /// 
        /// </summary>
        /// <param DateTime="fecha1"></param>
        /// <param DateTime="fecha2"></param>
        /// <param Numero_Habitación="numeroHabitacion"></param>
        /// <returns></returns>
        [HttpGet("~/Mantenimientos/MantenimientosEntreFechas")]
        public ActionResult MantenimientoEntreFechas(DateTime fecha1, DateTime fecha2, int numeroHabitacion)
        {
            try
            {
                if (fecha1> fecha2)
                {
                    throw new MantenimientoDateException("La primer fecha no puede ser mayor a la segunda fecha!");
                }
                var list = _mantCabanaId.MantenimientoXidCabana(numeroHabitacion).OrderByDescending(x => x.Costo);
                var aux = _getBetweenDates.MantenimientoPorFechas(fecha1, fecha2, numeroHabitacion);
                if (aux.IsNullOrEmpty())
                {
                    throw new MantenimientoSearchException($"No se han encontrado mantenimientos entre las fechas {fecha1.ToShortDateString} " +
                        $"- {fecha2.ToShortDateString} y la habitación número {numeroHabitacion}");
                }
                return Ok(aux);
            }
            catch (MantenimientoSearchException e)
            {

                return BadRequest(e.Message);
            }
        }


        // POST api/<MantenimientosController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDto"></param>
        /// <param name="cabanaId"></param>
        /// <returns></returns>
        [HttpPost("~/Mantenimientos/AltaMantenimiento")]
        public ActionResult Post(MantenimientoDTO objDto, int cabanaId)
        {
            if (objDto == null) return BadRequest("Debe proporcionar un mantenimiento para ser dado de alta!");
            try
            {
                Mantenimiento mantenimiento = _mapper.Map<Mantenimiento>(objDto);
                Cabana cabana = _buscarCabana.EncontrarNumHab(cabanaId);
                
                _verificar.VerificarMantenimientos(cabanaId, objDto.FechaMantenimiento);
                mantenimiento.Cabana = cabana;

                _altaMantenimiento.NuevoMantenimiento(mantenimiento);
                return Ok($"Se ha añadido el mantenimiento a la cabaña {cabana.Nombre.Data}");
            }
            catch (MantenimientoCreateException e)
            {

                return BadRequest(e.Message);
            }

        }

    
       


    }
}
