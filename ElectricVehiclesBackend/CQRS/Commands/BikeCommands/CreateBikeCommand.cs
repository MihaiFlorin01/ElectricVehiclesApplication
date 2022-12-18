using Dtos.BikeDtos;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class CreateBikeCommand : IRequest<CreateBikeDto>
    {
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
