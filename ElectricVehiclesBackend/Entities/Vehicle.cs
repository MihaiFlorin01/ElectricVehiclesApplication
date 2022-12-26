using Abstractions;

namespace Entities
{
    public class Vehicle : BaseEntityModel
    {
        public string? Type { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}