using Entities;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class CreateBikeCommand : IRequest<Bike>
    {
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
