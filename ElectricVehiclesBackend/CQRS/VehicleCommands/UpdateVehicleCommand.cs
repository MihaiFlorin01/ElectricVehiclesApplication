using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class UpdateVehicleCommand : IRequest<UpdateVehicleDto>
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
    }
}
