using CodeFirst.Domain.BaseEntities;
using System.Collections.Generic;

namespace CodeFirst.Domain.Entities
{
    public class EstadoProyecto : BaseEntity
    {
        public EstadoProyecto()
        {
            this.Proyectos = new HashSet<Proyecto>();
        }

        public string Nombre { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}