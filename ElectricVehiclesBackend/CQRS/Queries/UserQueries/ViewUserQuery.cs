using Common.Enums;

namespace CQRS.Queries.UserQueries
{
    public class ViewUserQuery
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }
}
