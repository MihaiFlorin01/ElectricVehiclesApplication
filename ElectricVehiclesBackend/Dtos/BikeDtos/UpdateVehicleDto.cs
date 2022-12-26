namespace Dtos.VehicleDtos
{
    public class UpdateVehicleDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
    }
}
