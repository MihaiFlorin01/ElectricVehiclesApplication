using Abstractions;
using AutoMapper;
using Dtos.BikeDtos;
using Entities;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, CreateBikeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CreateBikeDto> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = _mapper.Map<Bike>(request);
            var bikeToAdd = _unitOfWork.GetRepository<Bike>().Add(bike);

            return Task.FromResult(_mapper.Map<CreateBikeDto>(bikeToAdd));
        }
    }
}
