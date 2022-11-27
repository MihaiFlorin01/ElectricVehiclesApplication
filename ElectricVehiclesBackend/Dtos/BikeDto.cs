namespace Dtos
{
    public class BikeDto
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<RentalDto>? Rentals { get; set; }
    }
}