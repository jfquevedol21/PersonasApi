using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonasAPI.DAL.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public byte IdDocumento { get; set; }
        public byte IdGenero { get; set; }
      
        public string? Nombre { get; set; }
        
        public string? Apellido { get; set; } 
        public string NumeroDocumento { get; set; } = null!;
        
        public DateTime? FechaNacimiento { get; set; } 
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
