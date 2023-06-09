using AutoMapper;
using LogicaAplicacion.CasosDeUso.Cabanas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using WebApi.DTOs;


namespace WebApi.Mapper
{
    public class MapperProfile : Profile
    {




        public MapperProfile()
        {

            CreateMap<CabanaDTO, Cabana>()
                
                .ForMember(cabana => cabana.Nombre, cabanaDTO => cabanaDTO.MapFrom(campo => new Nombre(campo.Nombre)))
                .ForMember(cabana => cabana.Descripcion, cabanaDTO => cabanaDTO.MapFrom(campo => new Descripcion(campo.Descripcion)))
                .ForMember(cabana => cabana.NombreTipo, cabanaDTO => cabanaDTO.MapFrom(campo => new Nombre(campo.NombreTipo)))
                .ForMember(cabana => cabana.Jacuzzi, cabanaDTO => cabanaDTO.MapFrom(campo => new Jacuzzi(campo.Jacuzzi)))
                .ForMember(cabana => cabana.HabilitadoAReservas, cabanaDTO => cabanaDTO.MapFrom(campo => new HabilitadaReserva(campo.HabilitadoAReservas)))
                .ForMember(cabana => cabana.CapacidadHabitacion, cabanaDTO => cabanaDTO.MapFrom(campo => new CapacidadHabitacion(campo.CapacidadHabitacion)));


            CreateMap<MantenimientoDTO, Mantenimiento>().
                ForMember(mantenimiento => mantenimiento.Id, mantenimientoDTO => mantenimientoDTO.MapFrom(campo => campo.Id)).
                ForMember(mantenimiento => mantenimiento.FechaMantenimiento, mantenimientoDTO => mantenimientoDTO.MapFrom(campo => campo.FechaMantenimiento)).
                ForMember(mantenimiento => mantenimiento.Descripcion, mantenimientoDTO => mantenimientoDTO.MapFrom(campo => new Descripcion(campo.Descripcion))).
                ForMember(mantenimiento => mantenimiento.Costo, mantenimientoDTO => mantenimientoDTO.MapFrom(campo => new Costo(campo.Costo))).
                ForMember(mantenimiento => mantenimiento.Operador, mantenimientoDTO => mantenimientoDTO.MapFrom(campo => new Operador(campo.Operador))).
                ForMember(mantenimiento => mantenimiento.Cabana, mantenimientoDTO => mantenimientoDTO.MapFrom(campo => campo.CabanaId));

            CreateMap<TipoDTO, Tipo>().
                ForMember(tipo => tipo.Nombre, tipoDTO => tipoDTO.MapFrom(campo => campo.Nombre)).
                ForMember(tipo => tipo.Descripcion, tipoDTO => tipoDTO.MapFrom(campo => new Descripcion(campo.Descripcion))).
                ForMember(tipo => tipo.CostoHuesped, tipoDTO => tipoDTO.MapFrom(campo => new Costo(campo.CostoHuesped)));

            CreateMap<UsuarioDTO, Usuario>().
                ForMember(usuario => usuario.Email, usuarioDTO => usuarioDTO.MapFrom(campo => campo.Email)).
                ForMember(usuario => usuario.PassWord, usuarioDTO => usuarioDTO.MapFrom(campo => new Password(campo.Password)));

            CreateMap<Cabana, CabanaDTO>().
                //ForMember(cabanaDTO => cabanaDTO.NumeroHabitacion, cabana => cabana.MapFrom(campo => campo.NumeroHabitacion)).
                ForMember(cabanaDTO => cabanaDTO.Nombre, cabana => cabana.MapFrom(campo => campo.Nombre.Data)).
                ForMember(cabanaDTO => cabanaDTO.Descripcion, cabana => cabana.MapFrom(campo => campo.Descripcion.Data)).
                ForMember(cabanaDTO => cabanaDTO.NombreTipo, cabana => cabana.MapFrom(campo => campo.NombreTipo.Data)).
                ForMember(cabanaDTO => cabanaDTO.Jacuzzi, cabana => cabana.MapFrom(campo => campo.Jacuzzi.Data)).
                ForMember(cabanaDTO => cabanaDTO.HabilitadoAReservas, cabana => cabana.MapFrom(campo => campo.HabilitadoAReservas.Data)).
                ForMember(cabanaDTO => cabanaDTO.CapacidadHabitacion, cabana => cabana.MapFrom(campo => campo.CapacidadHabitacion.Data));

            CreateMap<Mantenimiento, MantenimientoDTO>().
                ForMember(mantenimientoDTO => mantenimientoDTO.Id, mantenimiento => mantenimiento.MapFrom(campo => campo.Id)).
                ForMember(mantenimientoDTO => mantenimientoDTO.FechaMantenimiento, mantenimiento => mantenimiento.MapFrom(campo => campo.FechaMantenimiento)).
                ForMember(mantenimientoDTO => mantenimientoDTO.Descripcion, mantenimiento => mantenimiento.MapFrom(campo => campo.Descripcion.Data)).
                ForMember(mantenimientoDTO => mantenimientoDTO.Costo, mantenimiento => mantenimiento.MapFrom(campo => campo.Costo.Data)).
                ForMember(mantenimientoDTO => mantenimientoDTO.Operador, mantenimiento => mantenimiento.MapFrom(campo => campo.Operador.Data)).
                ForMember(mantenimientoDTO => mantenimientoDTO.CabanaId, mantenimiento => mantenimiento.MapFrom(campo => campo.Cabana.NumeroHabitacion));

            CreateMap<Tipo, TipoDTO>().
                ForMember(tipoDTO => tipoDTO.Nombre, tipo => tipo.MapFrom(campo => campo.Nombre)).
                ForMember(tipoDTO => tipoDTO.Descripcion, tipo => tipo.MapFrom(campo => campo.Descripcion.Data)).
                ForMember(tipoDTO => tipoDTO.CostoHuesped, tipo => tipo.MapFrom(campo => campo.CostoHuesped.Data));

            CreateMap<Usuario, UsuarioDTO>().
                ForMember(usuarioDTO => usuarioDTO.Email, usuario => usuario.MapFrom(campo => campo.Email)).
                ForMember(usuarioDTO => usuarioDTO.Password, usuario => usuario.MapFrom(campo => campo.PassWord.Data));

        }
    }
}
