using CodeFirst.Domain.BaseEntities;

namespace CodeFirst.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}