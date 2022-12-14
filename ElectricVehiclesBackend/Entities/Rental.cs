using Abstractions;

namespace Entities
{
    public class Rental : BaseEntityModel
    {
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
        
    }
}
