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
        public async Task<ActionResult<ViewBikeDto>> AddBike(CreateBikeDto createBikeDto)
        {
            var bike = _mapper.Map<CreateBikeCommand>(createBikeDto);

            var bikeToSend = await _mediator.Send(bike);

            await _unitOfWork.SaveChangesAsync();

            var bikeToReturn = _mapper.Map<ViewBikeDto>(bikeToSend);

            return Ok(bikeToReturn);
        }

        [HttpPut]
        public async Task<ActionResult<ViewBikeDto>> UpdateBike(UpdateBikeDto updateBikeDto)
        {
            var bike = _mapper.Map<UpdateBikeCommand>(updateBikeDto);

            var bikeToSend = await _mediator.Send(bike);

            await _unitOfWork.SaveChangesAsync();

            var bikeToReturn = _mapper.Map<ViewBikeDto>(bikeToSend);

            return Ok(bikeToReturn);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<ViewBikeDto>> DeleteBike(int id)
        //{
        //    var bike = await _unitOfWork.GetRepository<Bike>().GetByIdAsync(id);
        //    if (bike == null)
        //    {
        //        return NotFound();
        //    }
        //    await _mediator.Send();

        //    return Ok(_mapper.Map<ViewBikeDto>(bike));
        //}
    }
}
