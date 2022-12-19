namespace Dtos.BikeDtos
{
    public class CreateBikeDto
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
