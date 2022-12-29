using Abstractions;
using Utils.Enums;

namespace Entities
{
    public class User : BaseEntityModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }       
        public UserRole Role { get; set; }
    }
}
