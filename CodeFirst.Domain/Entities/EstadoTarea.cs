using CodeFirst.Domain.BaseEntities;
using System.Collections.Generic;

namespace CodeFirst.Domain.Entities
{
    public class EstadoTarea : BaseEntity
    {
        public EstadoTarea()
        {
            Tareas = new HashSet<Tarea>();
        }

        public string Nombre { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}