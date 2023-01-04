using Abstractions;
using AutoMapper;
using Dtos.VehicleDtos;
using Entities;
using MediatR;

namespace CQRS.VehicleQueries
{
    public class GetByIdVehicleHandler : IRequestHandler<GetByIdVehicleQuery, ViewVehicleDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdVehicleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ViewVehicleDto> Handle(GetByIdVehicleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<Vehicle>().GetByIdAsync(request.Id);

            var entityMapped = _mapper.Map<ViewVehicleDto>(entity);

            return entityMapped;
        }
    }
}
