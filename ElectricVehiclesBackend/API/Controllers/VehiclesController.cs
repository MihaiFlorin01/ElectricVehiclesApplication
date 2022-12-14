using AutoMapper;
using Dtos.VehicleDtos;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Abstractions;
using System.Net.Mime;
using MediatR;
using CQRS.VehicleQueries;
using CQRS.VehicleCommands;
using Dtos.VehicleTypeDtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehiclesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewVehicleDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewVehicleDto>>> GetVehicles()
        {
            var vehicles = await _unitOfWork.GetRepository<Vehicle>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewVehicleDto>>(vehicles));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetVehicleById")]
        public async Task<ActionResult<ViewVehicleDto>> GetVehicleById(int id)
        {
            var vehicle = await _unitOfWork.GetRepository<Vehicle>().GetByIdAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ViewVehicleDto>(vehicle));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ViewVehicleDto>> AddVehicle(CreateVehicleDto createVehicleDto)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(createVehicleDto);

            _unitOfWork.GetRepository<Vehicle>().Add(vehicleEntity);

            await _unitOfWork.SaveChangesAsync();

            var vehicleToReturn = _mapper.Map<CreateVehicleDto>(vehicleEntity);

            return CreatedAtRoute("GetVehicleTypeById", new { id = vehicleEntity.Id }, vehicleToReturn);
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

            if (vehicleEntity.Id <= 0)
            {
                return BadRequest();
            }

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
            var vehicle = await _unitOfWork.GetRepository<Vehicle>().GetByIdAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            await _unitOfWork.GetRepository<Vehicle>().DeleteByIdAsync(vehicle.Id);

            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<ViewVehicleDto>(vehicle));
        }
    }
}
