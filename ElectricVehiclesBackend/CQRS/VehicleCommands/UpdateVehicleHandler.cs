using Abstractions;
using AutoMapper;
using Dtos.VehicleDtos;
using Entities;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, UpdateVehicleDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateVehicleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UpdateVehicleDto> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entityUnmapped = _mapper.Map<Vehicle>(request);

            var entity = _unitOfWork.GetRepository<Vehicle>().Update(entityUnmapped);

            await _unitOfWork.SaveChangesAsync();

            var entityMapped = _mapper.Map<UpdateVehicleDto>(entity);

            return entityMapped;
        }
    }
}
