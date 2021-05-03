using APITienda.Models;
using APITienda.Models.DTOs;
using AutoMapper;

namespace APITienda.Mapper
{
    public class MiMapper : Profile
    {
        public MiMapper()
        {
            CreateMap<Persona, PersonaDto>().ReverseMap();
        }
    }
}
