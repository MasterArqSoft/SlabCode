using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Core.DTOs
{
    public class CambioPasswordDto
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string NuevoPassword { get; set; }
    }
}
