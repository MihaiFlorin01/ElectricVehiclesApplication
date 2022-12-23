using Abstractions;

namespace Entities
{
    public class VehicleType : BaseEntityModel
    {
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
