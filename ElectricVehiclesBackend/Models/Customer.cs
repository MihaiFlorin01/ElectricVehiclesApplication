using Abstractions;

namespace Entities
{
    public class Customer : BaseEntityModel
    {
        public string? Name { get; set; }
        public string? BillingAddress { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
