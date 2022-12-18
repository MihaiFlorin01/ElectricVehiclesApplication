using Abstractions;
using AutoMapper;
using Dtos.BikeTypeDtos;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BikeTypesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewBikeTypeDto>>> GetBikeTypes()
        {
            var bikeTypes = await _unitOfWork.GetRepository<BikeType>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewBikeTypeDto>>(bikeTypes.Where(x =>x.IsDeleted == false)));
        }

        [HttpGet("{id}", Name = "GetBikeTypeById")]
        public async Task<ActionResult<ViewBikeTypeDto>> GetBikeTypeById(long id)
        {
            var bikeType = await _unitOfWork.GetRepository<BikeType>().GetByIdAsync(id);
            if (bikeType == null || bikeType.IsDeleted == true)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ViewBikeTypeDto>(bikeType));
        }

        [HttpPost]
        public async Task<ActionResult<ViewBikeTypeDto>> AddBikeType(CreateBikeTypeDto createBikeTypeDto)
        {
            var bikeTypeEntity = _mapper.Map<BikeType>(createBikeTypeDto);
            _unitOfWork.GetRepository<BikeType>().Add(bikeTypeEntity);
            await _unitOfWork.SaveChangesAsync();
            var bikeTypeToReturn = _mapper.Map<CreateBikeTypeDto>(bikeTypeEntity);

            return CreatedAtRoute("GetBikeTypeById", new { id = bikeTypeEntity.Id }, bikeTypeToReturn);
        }

        [HttpPut]
        public async Task<ActionResult<ViewBikeTypeDto>> UpdateBikeType(UpdateBikeTypeDto updateBikeTypeDto)
        {
            var bikeTypeEntity = _mapper.Map<BikeType>(updateBikeTypeDto);
            if (bikeTypeEntity.Id <= 0)
            {
                return BadRequest();
            }
            _unitOfWork.GetRepository<BikeType>().Update(bikeTypeEntity);
            await _unitOfWork.SaveChangesAsync();
            var bikeTypeToReturn = _mapper.Map<ViewBikeTypeDto>(bikeTypeEntity);

            return Ok(bikeTypeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewBikeTypeDto>> DeleteBikeType(int id)
        {
            var bikeType = await _unitOfWork.GetRepository<BikeType>().GetByIdAsync(id);
            if (bikeType == null)
            {
                return NotFound();
            }
            await _unitOfWork.GetRepository<BikeType>().DeleteByIdAsync(bikeType.Id);
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<ViewBikeTypeDto>(bikeType));

        }
    }
}
