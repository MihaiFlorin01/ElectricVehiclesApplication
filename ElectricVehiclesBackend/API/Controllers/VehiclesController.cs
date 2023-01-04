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
        public async Task<ActionResult<IEnumerable<ViewVehicleDto>>> GetVehicles()
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
        public async Task<ActionResult<ViewVehicleDto>> GetVehicleById(int id)
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
            var result = await _mediator.Send(new CreateVehicleCommand()
            {
                Type = createVehicleDto.Type,
                RegisterDate = createVehicleDto.RegisterDate,
            });

            return Ok(result);
        }     

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]   
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<ViewVehicleDto>> UpdateVehicle(UpdateVehicleDto updateVehicleDto)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(updateVehicleDto);

            _unitOfWork.GetRepository<Vehicle>().Update(vehicleEntity);

            await _unitOfWork.SaveChangesAsync();

            var vehicleToReturn = _mapper.Map<ViewVehicleDto>(vehicleEntity);

            return Ok(vehicleToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewVehicleDto>> DeleteVehicle(int id)
        {
            var vehicleEntity = await _unitOfWork.GetRepository<Vehicle>().GetByIdAsync(id);

            if (vehicleEntity == null)
            {
                return NotFound();
            }

            await _unitOfWork.GetRepository<Vehicle>().DeleteByIdAsync(id);

            await _unitOfWork.SaveChangesAsync();

            var vehicleToReturn = _mapper.Map<ViewVehicleDto>(vehicleEntity);

            return Ok(vehicleToReturn);
        }
    }
}
