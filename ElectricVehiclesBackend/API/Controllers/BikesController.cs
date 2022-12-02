using Abstractions;
using AutoMapper;
using Dtos.BikeDtos;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BikesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper= mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<BikeDto>), 200)]
        public async Task<ActionResult<IEnumerable<ViewBikeDto>>> GetBikes()
        {
            var bikes = await _unitOfWork.GetRepository<Bike>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewBikeDto>>(bikes.Where(x => x.IsDeleted == false)));
        }

        [HttpGet("{id}", Name ="GetBikeById")]
        public async Task<ActionResult<ViewBikeDto>> GetBikeById(long id)
        {
            var bike = await _unitOfWork.GetRepository<Bike>().GetByIdAsync(id);
            if (bike == null || bike.IsDeleted == true)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ViewBikeDto>(bike));
        }

        [HttpPost]
        public async Task<ActionResult<ViewBikeDto>> AddBike(CreateBikeDto createBikeDto)
        {
            var bikeEntity = _mapper.Map<Bike>(createBikeDto);
            _unitOfWork.GetRepository<Bike>().Add(bikeEntity);
            await _unitOfWork.SaveChangesAsync();
            var bikeToReturn = _mapper.Map<ViewBikeDto>(bikeEntity);

            return CreatedAtRoute("GetBikeById", new { id = bikeEntity.Id }, bikeToReturn);
        }

        [HttpPut]
        public async Task<ActionResult<ViewBikeDto>> UpdateBike(UpdateBikeDto updateBikeDto)
        {
            var bikeEntity = _mapper.Map<Bike>(updateBikeDto);
            if (bikeEntity.Id <= 0)
            {
                return BadRequest();
            }
            _unitOfWork.GetRepository<Bike>().Update(bikeEntity);
            await _unitOfWork.SaveChangesAsync();
            var bikeToReturn = _mapper.Map<ViewBikeDto>(bikeEntity);

            return Ok(bikeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewBikeDto>> DeleteBike(int id)
        {
            var bike = await _unitOfWork.GetRepository<Bike>().GetByIdAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            await _unitOfWork.GetRepository<Bike>().DeleteByIdAsync(bike.Id);
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<ViewBikeDto>(bike));
        }
    }
}
