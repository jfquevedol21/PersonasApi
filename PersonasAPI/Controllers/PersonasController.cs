using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasAPI.BLL.Services;
using PersonasAPI.BLL.ViewModels;
//using PersonasAPI.DAL.Data;
using PersonasAPI.DAL.Models;

namespace PersonasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        public PersonaService _personaService;
        public GeneroService _generoService;
        public DocumentosService _documentoService;

        public PersonasController(PersonaService personaService, 
                                    GeneroService generoService, 
                                    DocumentosService documentoService)
        {
            _personaService = personaService;
            _generoService = generoService;
            _documentoService = documentoService;   
        }

        //GET: api/Personas
        [HttpGet]
        public IActionResult GetPersonas()
        {
            var personas = _personaService.getPersonas();
            var respuesta = new Respuesta();
            if (personas.Count == 0)
            {
                respuesta.State = false;
                respuesta.Result = null;
                respuesta.Message = "No hay elementos en la tabla personas";
                return NotFound(respuesta);
            }

            respuesta.State = true;
            respuesta.Result = personas;
            respuesta.Message = "Obtenido con éxito";

            return Ok(respuesta);
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public IActionResult GetPersona(int id)
        {
            var persona = _personaService.getPersonaById(id);
            var respuesta = new Respuesta();
            if (persona == null)
            {
                respuesta.Result = null;
                respuesta.State = false;
                respuesta.Message = "No se encontró persona con Id " + id;
                return NotFound(persona);
            }
            respuesta.Result = persona;
            respuesta.State = true;
            respuesta.Message = "Ejecutado con éxito";


            return Ok(respuesta);
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutPersona(int id, PersonaVM persona)
        {
            var respuesta = new Respuesta();
            var pers = _personaService.getPersonaById(id);
            var idGen = _generoService.getGeneroById(persona.IdGenero);
            var idDoc = _documentoService.getDocumentoById(persona.IdDocumento);

            if (idGen == null) 
            {
                respuesta.State = false;
                respuesta.Result = null;
                respuesta.Message = "No existe genero con id " + persona.IdGenero;
                return NotFound(respuesta);
            }

            if (idDoc == null)
            {
                respuesta.State = false;
                respuesta.Result = null;
                respuesta.Message = "No existe documento con id " + persona.IdGenero;
                return NotFound(respuesta);
            }

            if (pers == null)
            {
                respuesta.State = false;
                respuesta.Result = null;
                respuesta.Message = "No existe persona con id " + id;
                return NotFound(respuesta);
            }

            var updatedPersona = _personaService.updatePersona(id, persona);
            respuesta.State = true;
            respuesta.Result = updatedPersona;
            respuesta.Message = "Actualización exitosa";

            return Ok(respuesta);
        }

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostPersona([FromBody]PersonaVM persona)
        {
            var respuesta = new Respuesta();
            var idGen = _generoService.getGeneroById(persona.IdGenero);
            var idDoc = _documentoService.getDocumentoById(persona.IdDocumento);

            if (idGen == null)
            {
                respuesta.State = false;
                respuesta.Result = null;
                respuesta.Message = "No existe genero con id " + persona.IdGenero;
                return NotFound(respuesta);
            }

            if (idDoc == null)
            {
                respuesta.State = false;
                respuesta.Result = null;
                respuesta.Message = "No existe documento con id " + persona.IdGenero;
                return NotFound(respuesta);
            }

            if(persona.Apellido == null || persona.Nombre== null  || persona.FechaNacimiento == null)
            {
                respuesta.State = false;
                respuesta.Result = null;
                respuesta.Message = "Error en Apellido, Nombre o Fecha de Nacimiento";
                return NotFound(respuesta);
            }

            respuesta.State = true;
            respuesta.Result = persona;
            respuesta.Message = "Creación de persona exitosa";

            _personaService.AddPersona(persona);
            
            return Ok(respuesta);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var respuesta = new Respuesta();
            var pers = _personaService.getPersonaById(id);
            if (pers == null)
            {
                respuesta.State = false;
                respuesta.Result = null;
                respuesta.Message = "No existe persona con id " + id;
                return NotFound(respuesta);
            }
            respuesta.Result = null;
            respuesta.State = true;
            respuesta.Message = "Eliminado con éxito";
            _personaService.DeletePersona(id);

           
            return Ok(respuesta);
        }
        
        
    }
}
