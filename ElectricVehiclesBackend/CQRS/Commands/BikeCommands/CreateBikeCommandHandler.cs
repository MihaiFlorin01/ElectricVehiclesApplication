using Abstractions;
using AutoMapper;
using Entities;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, Bike>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Bike> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unitOfWork.GetRepository<Bike>().Add(_mapper.Map<Bike>(request)));
        }
    }
}
