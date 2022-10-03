using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonasAPI.DAL.Models
{
    public partial class Genero
    {
        public Genero()
        {
            
        }

        public byte Id { get; set; }
        [Required(ErrorMessage = "Se requiere un nombre de género")]
        public string GeneroName { get; set; } = null!;

    }
}
