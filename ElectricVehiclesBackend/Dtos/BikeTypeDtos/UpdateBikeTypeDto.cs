namespace Dtos.BikeTypeDtos
{
    public class UpdateBikeTypeDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
