using System;

namespace CodeFirst.Core.DTOs
{
    public class TareaDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEjecucion { get; set; }
        public int IdProyecto { get; set; }
    }
}