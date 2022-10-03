using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasAPI.BLL.ViewModels
{
    public class PersonaVM
    {
        public byte IdDocumento { get; set; }
        public byte IdGenero { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        
    }
}
