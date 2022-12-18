using Abstractions;
using Entities;
using MediatR;

namespace CQRS.Queries.BikeQueries
{
    public class ViewBikeQueryHandler : IRequestHandler<ViewBikeQuery, IEnumerable<Bike>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ViewBikeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Bike>> Handle(ViewBikeQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetRepository<Bike>().GetAllAsync();
        }
    }
}
