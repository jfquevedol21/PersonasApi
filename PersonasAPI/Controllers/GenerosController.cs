using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasAPI.BLL.Services;
using PersonasAPI.BLL.ViewModels;
using PersonasAPI.DAL.Data;
//using PersonasAPI.DAL.Data;
using PersonasAPI.DAL.Models;

namespace PersonasAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroService _generoService;
        

        public GenerosController(GeneroService generoService)
        {
            _generoService = generoService;
        }

        // GET: api/Generos
        [HttpGet]
        public IActionResult GetGeneros()
        {
            var generos = _generoService.getGeneros();
            var respuesta = new Respuesta();

            if (generos.Count == 0)
            {
                respuesta.Message = "No hay géneros en la BD";
                respuesta.State = false;
                respuesta.Result = null;
                return NotFound(respuesta);
            }

            respuesta.Message = "Géneros obtenidos correctamente";
            respuesta.State = true;
            respuesta.Result = generos;

            return Ok(respuesta);
        }

        // GET: api/Generos/5
        [HttpGet("{id}")]
        public IActionResult GetGenero(byte id)
        {
            var genero = _generoService.getGeneroById(id);
            var respuesta = new Respuesta();
            if (genero == null)
            {
                respuesta.State = false;
                respuesta.Message = "No se encontró género con id " + id;
                respuesta.Result = null;
                return NotFound(respuesta);
            }
            respuesta.State = true;
            respuesta.Message = "Genero obtenido con éxito";
            respuesta.Result = genero;


            return Ok(respuesta);
        }

        // PUT: api/Generos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutGenero(byte id, GeneroVM genero)
        {
            var respuesta = new Respuesta();
            var updatedGenero = _generoService.updateGenero(id, genero);
            if (updatedGenero == null)
            {
                respuesta.State = false;
                respuesta.Message = "No se encontró género con id " + id;
                respuesta.Result = null;
                return NotFound(respuesta);
            } else if (genero.GeneroName == null)
            {
                respuesta.Message = "Error en el parámetro generoName";
                respuesta.State = false;
                respuesta.Result = null;
            }
            respuesta.State = true;
            respuesta.Message = "Género actualizado con éxito";
            respuesta.Result = updatedGenero;

            return Ok(respuesta);
        }

        // POST: api/Generos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostGenero([FromBody]GeneroVM genero)
        {
            var respuesta = new Respuesta();
            
            if (genero.GeneroName == null)
            {
                respuesta.Message = "Error en el parámetro generoName";
                respuesta.State = false;
                respuesta.Result = null;
                return BadRequest(respuesta);
            }
            else {
                respuesta.Message = "Genero añadido con éxito";
                respuesta.State = true;
                respuesta.Result = genero;
                _generoService.AddGenero(genero);
                return Ok(respuesta);
            }
            
            
            
        }

        // DELETE: api/Generos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGenero(byte id)
        {
            var respuesta = new Respuesta();
            var gen = _generoService.getGeneroById(id);
            if(gen == null)
            {
                respuesta.Result = null;
                respuesta.State = false;
                respuesta.Message = "No existe genero con id " + id;
                return NotFound(respuesta);
            }
            respuesta.Result = null;
            respuesta.State = true;
            respuesta.Message = "Genero eliminado exitosamente";
            _generoService.DeleteGenero(id);

            
            return Ok(respuesta);
        }
    }
}
