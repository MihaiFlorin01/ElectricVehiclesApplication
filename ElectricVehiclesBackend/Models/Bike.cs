using Abstractions;

namespace Entities
{
    public class Bike : BaseEntityModel
    {
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}