using CodeFirst.Domain.BaseEntities;
using System;

namespace CodeFirst.Domain.Entities
{
    public class Tarea : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEjecucion { get; set; }
        public int IdProyecto { get; set; }
        public int IdEstadoTarea { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual EstadoTarea Estado { get; set; }
    }
}