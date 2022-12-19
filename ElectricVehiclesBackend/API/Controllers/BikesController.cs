using AutoMapper;
using Dtos.BikeDtos;
using Microsoft.AspNetCore.Mvc;
using Entities;
using MediatR;
using CQRS.Queries.BikeQueries;
using CQRS.Commands.BikeCommands;
using Abstractions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BikesController(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<BikeDto>), 200)]
        public async Task<ActionResult<IEnumerable<ViewBikeDto>>> GetBikes()
        {
            var bikes = await _mediator.Send(new ViewBikesQuery());

            return Ok(_mapper.Map<IEnumerable<ViewBikeDto>>(bikes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewBikeDto>> GetBikeById(long id)
        {
            var bike = await _mediator.Send(new ViewBikeByIdQuery()
            {
                Id = id,
            });

            return Ok(_mapper.Map<ViewBikeDto>(bike));
        }

        [HttpPost]
        public async Task<IActionResult> AddBike(CreateBikeDto createBikeDto)
        {
            var bikeToSend = await _mediator.Send(new CreateBikeCommand()
            {
                Id = createBikeDto.Id,
                RegisterDate = createBikeDto.RegisterDate,
                Type = createBikeDto.Type,
            });

            await _unitOfWork.SaveChangesAsync();

            return Ok(bikeToSend);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBike(UpdateBikeDto updateBikeDto)
        {
            var bikeToSend = await _mediator.Send(new UpdateBikeCommand()
            {
                Id = updateBikeDto.Id,
                RegisterDate = updateBikeDto.RegisterDate,
                Type = updateBikeDto.Type,
            });

            await _unitOfWork.SaveChangesAsync();

            return Ok(bikeToSend);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBike(int id)
        {
            
            var bikeToSend = await _mediator.Send(new DeleteBikeByIdCommand()
            {
                Id = id
            });

            return Ok(bikeToSend);
        }
    }
}
