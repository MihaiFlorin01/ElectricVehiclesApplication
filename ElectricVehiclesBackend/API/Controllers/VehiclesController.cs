using AutoMapper;
using Dtos.VehicleDtos;
using Microsoft.AspNetCore.Mvc;
using CQRS.Queries.VehicleQueries;
using FluentValidation;
using Entities;
using Abstractions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<Vehicle> _validator;

        public VehiclesController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Vehicle> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<VehicleDto>), 200)]
        public async Task<ActionResult<IEnumerable<ViewVehicleDto>>> GetVehicles()
        {
            var vehicles = await _unitOfWork.GetRepository<Vehicle>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewVehicleDto>>(vehicles));
        }

        [HttpGet("{id}", Name = "GetVehicleById")]
        public async Task<ActionResult<ViewVehicleDto>> GetVehicleById(Guid id)
        {
            var vehicle = await _unitOfWork.GetRepository<Vehicle>().GetByIdAsync(id);

            if (vehicle == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<ViewVehicleDto>(vehicle));
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ViewVehicleDto>> AddVehicle(Guid id, CreateVehicleDto createVehicleDto)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(createVehicleDto);

            var validationResult = await _validator.ValidateAsync(vehicleEntity);
            
            if (!validationResult.IsValid)
            {
                BadRequest(validationResult);
            }

            _unitOfWork.GetRepository<Vehicle>().Add(vehicleEntity);

            await _unitOfWork.SaveChangesAsync();

            var vehicleToReturn = _mapper.Map<ViewVehicleDto>(vehicleEntity);

            return CreatedAtRoute("GetVehicleById", new {id = vehicleEntity.Id}, vehicleToReturn);
        }

        [HttpPut]
        public async Task<ActionResult<ViewVehicleDto>> UpdateVehicle(UpdateVehicleDto updateVehicleDto)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(updateVehicleDto);

            var validationResult = await _validator.ValidateAsync(vehicleEntity);

            if (!validationResult.IsValid)
            {
                BadRequest(validationResult);
            }

            _unitOfWork.GetRepository<Vehicle>().Update(vehicleEntity);

            await _unitOfWork.SaveChangesAsync();

            var vehicleToReturn = _mapper.Map<ViewVehicleDto>(vehicleEntity);

            return Ok(vehicleToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewVehicleDto>> DeleteVehicle(Guid id)
        {
            var vehicleEntity = await _unitOfWork.GetRepository<Vehicle>().GetByIdAsync(id);

            if (vehicleEntity == null)
            {
                return BadRequest();
            }

            await _unitOfWork.GetRepository<Vehicle>().DeleteByIdAsync(id);

            await _unitOfWork.SaveChangesAsync();

            var vehicleToReturn = _mapper.Map<ViewVehicleDto>(vehicleEntity);

            return Ok(vehicleToReturn);
        }
    }
}
