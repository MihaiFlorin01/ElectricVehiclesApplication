namespace Dtos.VehicleDtos
{
    public class UpdateVehicleDto
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
