using Dtos.BikeDtos;
using Entities;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class UpdateBikeCommand : IRequest<UpdateBikeDto>
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
