using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Core.DTOs
{
    public class ProyectoDto
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
    }
}