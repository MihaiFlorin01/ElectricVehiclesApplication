using Abstractions;
using AutoMapper;
using Entities;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteVehicleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetRepository<Vehicle>().DeleteByIdAsync(request.Id);

            await _unitOfWork.SaveChangesAsync();

            return request.Id;
        }
    }
}
