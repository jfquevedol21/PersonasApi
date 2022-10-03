using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasAPI.DAL.Models
{
    public class Respuesta
    {
        public string Message { get; set; }
        public bool State { get; set; }
        public Object Result { get; set; }
    }
}
