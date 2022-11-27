using Abstractions;

namespace Models
{
    public class Bike : BaseEntityModel
    {
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}