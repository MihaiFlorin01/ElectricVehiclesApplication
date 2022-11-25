namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BillingAddress { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
