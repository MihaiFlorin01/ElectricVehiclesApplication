using AutoMapper;
using Dtos.BikeDtos;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CQRS.Queries.BikeQueries;
using CQRS.Commands.BikeCommands;
using FluentValidation;
using Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<Bike> _validator;

        public BikesController(IMediator mediator, IMapper mapper, IValidator<Bike> validator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<BikeDto>), 200)]
        public async Task<ActionResult<IEnumerable<ViewBikeDto>>> GetBikes()
        {
            var bikes = await _mediator.Send(new ViewBikesQuery());

            return Ok(_mapper.Map<IEnumerable<ViewBikeDto>>(bikes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewBikeDto>> GetBikeById(Guid id)
        {
            var bike = await _mediator.Send(new ViewBikeByIdQuery()
            {
                Id = id,
            });

            return Ok(_mapper.Map<ViewBikeDto>(bike));
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ViewBikeDto>> AddBike(Guid id, CreateBikeDto createBikeDto)
        {
            var createBikeDtoMapped = _mapper.Map<Bike>(createBikeDto);

            var validationResult = await _validator.ValidateAsync(createBikeDtoMapped);
            
            if (!validationResult.IsValid)
            {
                BadRequest(validationResult);
            }

            var bikeToSend = await _mediator.Send(new CreateBikeCommand()
            {
                Id = id,
                Type = createBikeDto.Type,
                RegisterDate = createBikeDto.RegisterDate,
            });

            var bikeToSendMapped = _mapper.Map<ViewBikeDto>(bikeToSend);

            bikeToSendMapped.Id = id;

            return Ok(bikeToSendMapped);
        }

        [HttpPut]
        public async Task<ActionResult<ViewBikeDto>> UpdateBike(UpdateBikeDto updateBikeDto)
        {
            var updateBikeDtoMapped = _mapper.Map<Bike>(updateBikeDto);

            var validationResult = await _validator.ValidateAsync(updateBikeDtoMapped);

            if (!validationResult.IsValid)
            {
                BadRequest(validationResult);
            }

            var bikeToSend = await _mediator.Send(new UpdateBikeCommand()
            {
                Id = updateBikeDto.Id,
                RegisterDate = updateBikeDto.RegisterDate,
                Type = updateBikeDto.Type,
            });

            var bikeToSendMapped = _mapper.Map<ViewBikeDto>(bikeToSend);

            return Ok(bikeToSendMapped);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewBikeDto>> DeleteBike(Guid id)
        {
            var bikeToSend = await _mediator.Send(new DeleteBikeByIdCommand()
            {
                Id = id,
            });

            return Ok(bikeToSend);
        }
    }
}
