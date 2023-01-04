using Abstractions;
using AutoMapper;
using Entities;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVehicleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entityUnmapped = _mapper.Map<Vehicle>(request);

            var entity = _unitOfWork.GetRepository<Vehicle>().Add(entityUnmapped);

            await _unitOfWork.SaveChangesAsync();

            return entity.Id;
        }
    }
}
