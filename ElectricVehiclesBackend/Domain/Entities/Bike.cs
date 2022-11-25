namespace Domain.Entities
{
    public class Bike
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}