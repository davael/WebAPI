using APITienda.Models;
using APITienda.Models.DTOs;
using APITienda.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [HttpGet(Name = nameof(GetPersonas))]
        public async Task<ActionResult<List<PersonaDto>>> GetPersonas()
        {
            var listaPersonas = await _perRepo.GetAllAsync();
            var listaPersonasDTO = _mapper.Map<List<PersonaDto>>(listaPersonas);
            return listaPersonasDTO;
        }

        /// <summary>
        /// Crear nueva persona
        /// </summary>
        /// <param name="personaDto"> Esta es la persona que se va a crear</param>
        /// <returns></returns>
        [HttpPost(Name = nameof(CrearPersona))]
        public async Task<ActionResult> CrearPersona(PersonaDto personaDto)
        {
            if (personaDto is null)
            {
                return BadRequest(ModelState);
            }
            if (await _perRepo.ExistePersona(personaDto.TipoDoc, personaDto.NroDoc))
            {
                ModelState.AddModelError("", "La persona ya existe");
                return BadRequest(ModelState);
            }
            var persona = _mapper.Map<Persona>(personaDto);

            if (!await _perRepo.CreateAsync(persona))
            {
                ModelState.AddModelError("", $"Error al guardar la persona {persona.Apellido}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        /// <summary>
        /// Actualizar Persona
        /// </summary>
        /// <param name="perid">id de persona</param>
        /// <param name="personaDto">Objeto Completo persona</param>
        /// <returns>Devuelve NoContent si fue todo correctamente</returns>

        [HttpPut("{perid:int}", Name = nameof(ActualizarPersona))]
        public async Task<ActionResult> ActualizarPersona(int perid, PersonaDto personaDto)
        {
            if (personaDto is null || personaDto.Id != perid)
            {
                return BadRequest(ModelState);
            }
            var persona = _mapper.Map<Persona>(personaDto);
            if (!await _perRepo.UpdateAsync(perid, persona))
            {
                ModelState.AddModelError("", $"Error al guardar la persona {persona.Apellido}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
