using Abstractions;
using AutoMapper;
using Dtos.BikeDtos;
using Entities;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class UpdateBikeCommandHandler : IRequestHandler<UpdateBikeCommand, UpdateBikeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<UpdateBikeDto> Handle(UpdateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = _mapper.Map<Bike>(request);
            var bikeToUpdate = _unitOfWork.GetRepository<Bike>().Update(bike);

            return Task.FromResult(_mapper.Map<UpdateBikeDto>(bikeToUpdate));
        }
    }
}
