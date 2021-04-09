using CodeFirst.Domain.BaseEntities;
using CodeFirst.Domain.Enums;

namespace CodeFirst.Domain.Entities
{
    public class Seguridad : BaseEntity
    {
        public string UserName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Estado Activo { get; set; }
        public RoleType Role { get; set; }
    }
}