namespace Dtos
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? BillingAddress { get; set; }
        public ICollection<RentalDto>? Rentals { get; set; }
    }
}
