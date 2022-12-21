namespace Dtos.BikeDtos
{
    public class UpdateBikeDto
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
