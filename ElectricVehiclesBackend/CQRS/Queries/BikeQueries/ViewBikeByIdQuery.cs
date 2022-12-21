using Dtos.BikeDtos;
using MediatR;

namespace CQRS.Queries.BikeQueries
{
    public class ViewBikeByIdQuery : IRequest<ViewBikeDto>
    {
        public Guid Id { get; set; }
    }
}
