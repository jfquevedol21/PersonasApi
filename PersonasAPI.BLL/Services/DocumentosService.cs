using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonasAPI.BLL.ViewModels;
using PersonasAPI.DAL.Data;
//using PersonasAPI.DAL.Data;
using PersonasAPI.DAL.Models;

namespace PersonasAPI.BLL.Services
{

    public class DocumentosService
    {
         private PersonasContext _context;
         public DocumentosService(PersonasContext context)
         {
             _context=context;
         }

         public void AddDocumento(DocumentoVM documento)
         {
             var _documento = new Documento()
             {
                 Nombre = documento.Nombre,
                 Abreviatura = documento.Abreviatura
             };

             _context.Documentos.Add(_documento);
             _context.SaveChanges();
         }

         public List<Documento> getDocumentos()
         {
             return _context.Documentos.ToList();
         }

         public Documento getDocumentoById(byte Id)
         {
             return _context.Documentos.FirstOrDefault(documento=> documento.Id==Id);
         }

         public Documento updateDocumento(byte Id, DocumentoVM documento)
         {
             var _documento = _context.Documentos.FirstOrDefault(doc => doc.Id == Id);
             if (_documento != null)
             {
                 _documento.Nombre = documento.Nombre;
                 _documento.Abreviatura = documento.Abreviatura;
                 _context.SaveChanges();
             }

             return _documento;
         }

         public void DeleteDocumento(byte Id)
         {
             var _Documento = _context.Documentos.FirstOrDefault(doc => doc.Id==Id);
             if (_Documento != null) { 
                 _context.Documentos.Remove(_Documento);
                 _context.SaveChanges();
             }
         }
    }
}
