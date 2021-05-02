using APITienda.Models;
using APITienda.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
