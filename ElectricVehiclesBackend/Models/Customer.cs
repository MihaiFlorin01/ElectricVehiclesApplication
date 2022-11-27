using Abstractions;

namespace Models
{
    public class Customer : BaseEntityModel
    {
        public string? Name { get; set; }
        public string? BillingAddress { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
