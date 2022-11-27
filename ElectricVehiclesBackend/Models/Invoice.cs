using Abstractions;

namespace Models
{
    public class Invoice : BaseEntityModel
    {
        public decimal GrossAmount { get; set; }
        public decimal VAT { get; set; }
        public decimal NetAmount { get; set; }
        public bool Paid { get; set; }
    }
}
