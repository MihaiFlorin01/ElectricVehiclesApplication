using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleQueries
{
    public class GetAllVehiclesQuery : IRequest<IEnumerable<ViewVehicleDto>>
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
    }
}
