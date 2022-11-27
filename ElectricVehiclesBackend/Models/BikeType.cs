using Abstractions;

namespace Models
{
    public class BikeType : BaseEntityModel
    {
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
