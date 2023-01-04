using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleQueries
{
    public class GetByIdVehicleQuery : IRequest<ViewVehicleDto>
    {
        public int Id { get; set; }
    }
}
