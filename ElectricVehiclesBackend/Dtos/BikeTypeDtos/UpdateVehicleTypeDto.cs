namespace Dtos.VehicleTypeDtos
{
    public class UpdateVehicleTypeDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
