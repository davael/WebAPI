using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITienda.Models;
using APITienda.Models.DTOs;
using APITienda.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APITienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepository _perRepo;
        private readonly IMapper _mapper;

        public PersonasController(IPersonaRepository perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtener todas las personas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            var listaPersonas = await _perRepo.GetAllAsync();
            var listaPersonasDTO = _mapper.Map<List<PersonaDto>>(listaPersonas);
            return Ok(listaPersonasDTO);
        }

        /// <summary>
        /// Crear nueva persona
        /// </summary>
        /// <param name="personaDto"> Esta es la persona que se va a crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostPersona([FromBody] PersonaDto personaDto)
        {
            if(personaDto == null)
            {
                return BadRequest(ModelState);
            }
            if( await _perRepo.ExistePersona(personaDto.TipoDoc,personaDto.NroDoc))
            {
                ModelState.AddModelError("", "La persona ya existe");
                return StatusCode(404, ModelState);
            }
            var persona = _mapper.Map<Persona>(personaDto);

            if (!await _perRepo.CreateAsync(persona))
            {
                ModelState.AddModelError("", $"Error al guardar la persona {persona.Apellido}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        /// <summary>
        /// Actualizar Persona
        /// </summary>
        /// <param name="perid">id de persona</param>
        /// <param name="personaDto">Objeto Completo persona</param>
        /// <returns>Devuelve NoContent si fue todo correctamente</returns>

        [HttpPut("{perid:int}", Name ="PutPersona")]
        public async Task<IActionResult> PutPersona(int perid, [FromBody] PersonaDto personaDto)
        {
            if (personaDto == null || personaDto.Id != perid)
            {
                return BadRequest(ModelState);
            }
            var persona = _mapper.Map<Persona>(personaDto);
            if (! await _perRepo.UpdateAsync(perid,persona))
            {
                ModelState.AddModelError("", $"Error al guardar la persona {persona.Apellido}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
