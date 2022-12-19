using Dtos.BikeDtos;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class DeleteBikeByIdCommand : IRequest<DeleteBikeDto>
    {
        public long Id { get; set; }
    }
}
