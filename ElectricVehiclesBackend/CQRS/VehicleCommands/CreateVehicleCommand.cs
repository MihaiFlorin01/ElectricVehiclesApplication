using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class CreateVehicleCommand : IRequest<CreateVehicleDto>
    {
        public string? Type { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
    }
}
