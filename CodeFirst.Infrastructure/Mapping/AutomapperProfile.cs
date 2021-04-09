using AutoMapper;
using CodeFirst.Core.DTOs;
using CodeFirst.Domain.Entities;

namespace CodeFirst.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Tarea, TareaDto>();
            CreateMap<TareaDto, Tarea>();

            CreateMap<Proyecto, ProyectoDto>();
            CreateMap<ProyectoDto, Proyecto>();

            CreateMap<Seguridad, SeguridadDto>().ReverseMap();
        }
    }
}