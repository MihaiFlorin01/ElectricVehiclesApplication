using Abstractions;
using AutoMapper;
using Dtos.BikeDtos;
using Entities;
using MediatR;

namespace CQRS.Queries.BikeQueries
{
    public class ViewBikeByIdQueryHandler : IRequestHandler<ViewBikeByIdQuery, ViewBikeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ViewBikeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ViewBikeDto> Handle(ViewBikeByIdQuery request, CancellationToken cancellationToken)
        {
            var bike = await _unitOfWork.GetRepository<Bike>().GetByIdAsync(request.Id);
            var bikeToReturn = _mapper.Map<ViewBikeDto>(bike);

            return bikeToReturn;
        }
    }
}
