using Abstractions;
using AutoMapper;
using Dtos.VehicleTypeDtos;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Dtos.VehicleDtos;
using System.Net.Mime;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleTypesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }


        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewVehicleTypeDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewVehicleTypeDto>>> GetVehicleTypes()
        {
            var vehicleTypes = await _unitOfWork.GetRepository<VehicleType>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewVehicleTypeDto>>(vehicleTypes));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleTypeDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetVehicleTypeById")]
        public async Task<ActionResult<ViewVehicleTypeDto>> GetVehicleTypeById(int id)
        {
            var vehicleType = await _unitOfWork.GetRepository<VehicleType>().GetByIdAsync(id);
            
            if (vehicleType == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ViewVehicleTypeDto>(vehicleType));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleTypeDto), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ViewVehicleTypeDto>> AddVehicleType(CreateVehicleTypeDto createVehicleTypeDto)
        {
            var vehicleTypeEntity = _mapper.Map<VehicleType>(createVehicleTypeDto);
            
            _unitOfWork.GetRepository<VehicleType>().Add(vehicleTypeEntity);
            
            await _unitOfWork.SaveChangesAsync();
            
            var vehicleTypeToReturn = _mapper.Map<CreateVehicleTypeDto>(vehicleTypeEntity);

            return CreatedAtRoute("GetVehicleTypeById", new { id = vehicleTypeEntity.Id }, vehicleTypeToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleTypeDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<ViewVehicleTypeDto>> UpdateVehicleType(UpdateVehicleTypeDto updateVehicleTypeDto)
        {
            var vehicleTypeEntity = _mapper.Map<VehicleType>(updateVehicleTypeDto);
            
            if (vehicleTypeEntity.Id <= 0)
            {
                return BadRequest();
            }
            
            _unitOfWork.GetRepository<VehicleType>().Update(vehicleTypeEntity);
            
            await _unitOfWork.SaveChangesAsync();
            
            var vehicleTypeToReturn = _mapper.Map<ViewVehicleTypeDto>(vehicleTypeEntity);

            return Ok(vehicleTypeToReturn);
        }


        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleTypeDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewVehicleTypeDto>> DeleteVehicleType(int id)
        {
            var vehicleType = await _unitOfWork.GetRepository<VehicleType>().GetByIdAsync(id);
            
            if (vehicleType == null)
            {
                return NotFound();
            }
            
            await _unitOfWork.GetRepository<VehicleType>().DeleteByIdAsync(vehicleType.Id);
            
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<ViewVehicleTypeDto>(vehicleType));

        }
    }
}
