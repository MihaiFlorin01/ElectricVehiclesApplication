using AutoMapper;
using Dtos.VehicleDtos;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Abstractions;
using System.Net.Mime;
using MediatR;
using CQRS.VehicleQueries;
using CQRS.VehicleCommands;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehiclesController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewVehicleDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _mediator.Send(new GetAllVehiclesQuery());

            return Ok(vehicles);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await _mediator.Send(new GetByIdVehicleQuery()
            {
                Id = id
            });

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddVehicle(CreateVehicleDto createVehicleDto)
        {
            var vehicle = await _mediator.Send(new CreateVehicleCommand()
            {
                Type = createVehicleDto.Type,
                RegisterDate = createVehicleDto.RegisterDate,
            });

            return Ok(vehicle);
        }     

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]   
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdateVehicle(UpdateVehicleDto updateVehicleDto)
        {
            var vehicle = await _mediator.Send(new UpdateVehicleCommand()
            {
                Id = updateVehicleDto.Id,
                Type = updateVehicleDto.Type,
                RegisterDate = updateVehicleDto.RegisterDate,
            });
            
            return Ok(vehicle);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var result = await _mediator.Send(new DeleteVehicleCommand()
            {
                Id = id,
            });

            return Ok(result);
        }
    }
}
