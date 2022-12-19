using Dtos.BikeDtos;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class CreateBikeCommand : IRequest<CreateBikeDto>
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
