using CodeFirst.Domain.BaseEntities;
using System;
using System.Collections.Generic;

namespace CodeFirst.Domain.Entities
{
    public class Proyecto : BaseEntity
    {
        public Proyecto()
        {
            Tareas = new HashSet<Tarea>();
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public int IdEstadoProyecto { get; set; }

        public virtual EstadoProyecto Estado { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}