using Abstractions;
using AutoMapper;
using Dtos.VehicleDtos;
using Entities;
using MediatR;

namespace CQRS.VehicleQueries
{
    public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<ViewVehicleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllVehiclesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ViewVehicleDto>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.GetRepository<Vehicle>().GetAllAsync();

            var entitiesMapped = _mapper.Map<IEnumerable<ViewVehicleDto>>(entities);

            return entitiesMapped;
        }
    }
}
