using Abstractions;
using AutoMapper;
using Dtos.BikeDtos;
using Entities;
using MediatR;

namespace CQRS.Commands.BikeCommands
{
    public class DeleteBikeByIdCommandHandler : IRequestHandler<DeleteBikeByIdCommand, DeleteBikeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBikeByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteBikeDto> Handle(DeleteBikeByIdCommand request, CancellationToken cancellationToken)
        {
            var bike = await _unitOfWork.GetRepository<Bike>().GetByIdAsync(request.Id);
            bike.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            var bikeToDelete = _mapper.Map<DeleteBikeDto>(bike);

            return bikeToDelete;
        }
    }
}
