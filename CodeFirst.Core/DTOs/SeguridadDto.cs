using CodeFirst.Domain.Enums;

namespace CodeFirst.Core.DTOs
{
    public class SeguridadDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public Estado IsActive { get; set; }
        public string User { get; set; }
        public RoleType Role { get; set; }
    }
}