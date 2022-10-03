using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonasAPI.DAL.Models
{
    public partial class Documento
    {
        public Documento()
        {
            
        }

        public byte Id { get; set; }
        public string? Nombre { get; set; }
        public string? Abreviatura { get; set; }

        
    }
}
