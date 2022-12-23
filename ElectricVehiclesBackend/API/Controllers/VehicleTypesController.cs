using Abstractions;
using AutoMapper;
using Dtos.VehicleTypeDtos;
using Microsoft.AspNetCore.Mvc;
using Entities;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewVehicleTypeDto>>> GetVehicleTypes()
        {
            var VehicleTypes = await _unitOfWork.GetRepository<VehicleType>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewVehicleTypeDto>>(VehicleTypes.Where(x => x.IsDeleted == false)));
        }

        [HttpGet("{id}", Name = "GetVehicleTypeById")]
        public async Task<ActionResult<ViewVehicleTypeDto>> GetVehicleTypeById(int id)
        {
            var VehicleType = await _unitOfWork.GetRepository<VehicleType>().GetByIdAsync(id);
            
            if (VehicleType == null || VehicleType.IsDeleted == true)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ViewVehicleTypeDto>(VehicleType));
        }

        [HttpPost]
        public async Task<ActionResult<ViewVehicleTypeDto>> AddVehicleType(CreateVehicleTypeDto createVehicleTypeDto)
        {
            var VehicleTypeEntity = _mapper.Map<VehicleType>(createVehicleTypeDto);
            
            _unitOfWork.GetRepository<VehicleType>().Add(VehicleTypeEntity);
            
            await _unitOfWork.SaveChangesAsync();
            
            var VehicleTypeToReturn = _mapper.Map<CreateVehicleTypeDto>(VehicleTypeEntity);

            return CreatedAtRoute("GetVehicleTypeById", new { id = VehicleTypeEntity.Id }, VehicleTypeToReturn);
        }

        [HttpPut]
        public async Task<ActionResult<ViewVehicleTypeDto>> UpdateVehicleType(UpdateVehicleTypeDto updateVehicleTypeDto)
        {
            var VehicleTypeEntity = _mapper.Map<VehicleType>(updateVehicleTypeDto);
            
            if (VehicleTypeEntity.Id <= 0)
            {
                return BadRequest();
            }
            
            _unitOfWork.GetRepository<VehicleType>().Update(VehicleTypeEntity);
            
            await _unitOfWork.SaveChangesAsync();
            
            var VehicleTypeToReturn = _mapper.Map<ViewVehicleTypeDto>(VehicleTypeEntity);

            return Ok(VehicleTypeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewVehicleTypeDto>> DeleteVehicleType(int id)
        {
            var VehicleType = await _unitOfWork.GetRepository<VehicleType>().GetByIdAsync(id);
            
            if (VehicleType == null)
            {
                return NotFound();
            }
            
            await _unitOfWork.GetRepository<VehicleType>().DeleteByIdAsync(VehicleType.Id);
            
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<ViewVehicleTypeDto>(VehicleType));

        }
    }
}
