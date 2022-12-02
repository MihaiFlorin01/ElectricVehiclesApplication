namespace Dtos.BikeTypeDtos
{
    public class UpdateBikeTypeDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
