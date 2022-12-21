using Dtos.BikeDtos;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class DeleteBikeByIdCommand : IRequest<DeleteBikeDto>
    {
        public Guid Id { get; set; }
    }
}
