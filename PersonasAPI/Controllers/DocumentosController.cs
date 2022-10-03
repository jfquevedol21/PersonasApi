using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PersonasAPI.BLL.Services;
using PersonasAPI.BLL.ViewModels;
//using PersonasAPI.DAL.Data;
using PersonasAPI.DAL.Models;

namespace PersonasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        
        public DocumentosService _documentosService;


        public DocumentosController(DocumentosService documentosService)
        {
            _documentosService = documentosService; 
        }

        // GET: api/Documentos
        [HttpGet]
        public IActionResult GetDocumentos()
        {
            var documentos = _documentosService.getDocumentos();
            var respuesta = new Respuesta();
            if (documentos.Count == 0)
            {
                respuesta.Message = "No hay documentos en la BD";
                respuesta.State = false;
                respuesta.Result = null;
                return NotFound(respuesta);
            }
            respuesta.Message = "Documentos obtenidos exitosamente";
            respuesta.State = true;
            respuesta.Result = documentos;
            return Ok(respuesta);
        }

        // GET: api/Documentos/5
        [HttpGet("{id}")]
        public IActionResult GetDocumento(byte id)
        {
            var documento = _documentosService.getDocumentoById(id);
            var respuesta = new Respuesta();
            if (documento != null)
            {
               respuesta.State = true;
               respuesta.Message = "Obtenido con exito";
               respuesta.Result = documento;
            }
            else
            {
                respuesta.State = false;
                respuesta.Message = "No se encontró documento con id " + id;
                respuesta.Result = null;
                return NotFound(respuesta);
            }
            
            return Ok(respuesta);
        }

        // PUT: api/Documentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutDocumento(byte id, DocumentoVM documento)
        {
            var respuesta = new Respuesta();

            if (documento.Abreviatura==null || documento.Nombre==null)
            {
                respuesta.Message = "Error en los parámetros Abreviatura o Nombre";
                respuesta.State = false;
                respuesta.Result = null;
                return BadRequest(respuesta);
            }


            var updatedDocumento = _documentosService.updateDocumento(id, documento);
            

            if (updatedDocumento != null)
            {
                respuesta.Message = "Actualizado exitosamente";
                respuesta.State = true;
                respuesta.Result = updatedDocumento;
                return Ok(respuesta);
            }
            respuesta.Message = "No se encontró el documento a actualizar";
            respuesta.State = false;
            respuesta.Result = null;
            return NotFound(respuesta);

            
        }

        // POST: api/Documentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostDocumento([FromBody]DocumentoVM documento)
        {
            var respuesta = new Respuesta();

            if (documento.Abreviatura == null || documento.Nombre == null)
            {
                respuesta.Message = "Error en los parámetros Abreviatura o Nombre";
                respuesta.State = false;
                respuesta.Result = null;
                return BadRequest(respuesta);
            }

            respuesta.Message = "Documento creado con exito";
            respuesta.State = true;
            respuesta.Result = documento;

            _documentosService.AddDocumento(documento);
            
            return Ok(respuesta);
        }



        // DELETE: api/Documentos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDocumento(byte id)
        {
            var respuesta = new Respuesta();
            var doc = _documentosService.getDocumentoById(id);
            if(doc == null)
            {
                respuesta.Message = "No existe el documento con id "+id;
                respuesta.State = false;
                respuesta.Result = null;
                return NotFound(respuesta);
            }

            respuesta.Message = "Documento borrado exitosamente";
            respuesta.State = true;
            respuesta.Result = null;
            _documentosService.DeleteDocumento(id);



            return Ok(respuesta);
        }
        
    }
}
