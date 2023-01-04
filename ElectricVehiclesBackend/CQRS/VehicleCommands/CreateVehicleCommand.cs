using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class CreateVehicleCommand : IRequest<int>
    {
        public string? Type { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
    }
}
