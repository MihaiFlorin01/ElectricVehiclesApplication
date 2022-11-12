using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("bikes")]
    public class Bike
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}