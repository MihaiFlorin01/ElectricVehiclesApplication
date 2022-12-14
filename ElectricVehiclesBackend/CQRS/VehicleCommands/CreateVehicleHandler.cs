using Abstractions;
using AutoMapper;
using Dtos.VehicleDtos;
using Entities;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace CQRS.VehicleCommands
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVehicleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateVehicleDto> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entityUnmapped = _mapper.Map<Vehicle>(request);

            var entity = _unitOfWork.GetRepository<Vehicle>().Add(entityUnmapped);

            await _unitOfWork.SaveChangesAsync();

            var entityMapped = _mapper.Map<CreateVehicleDto>(entity);

            return entityMapped;
        }
    }
}
