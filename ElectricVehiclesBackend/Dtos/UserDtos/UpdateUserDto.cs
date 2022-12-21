using Common.Enums;

namespace Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }
}
