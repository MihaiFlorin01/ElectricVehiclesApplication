using Abstractions;
using AutoMapper;
using Dtos;
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
        [ProducesResponseType(typeof(IEnumerable<BikeDto>), 200)]
        public async Task<ActionResult<IEnumerable<BikeDto>>> GetBikes()
        {
            var bikes = await _unitOfWork.GetRepository<Bike>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<BikeDto>>(bikes));
        }

        [HttpGet("{id}", Name ="GetBikeById")]
        public async Task<ActionResult<BikeDto>> GetBikeById(long id)
        {
            var bike = await _unitOfWork.GetRepository<Bike>().GetByIdAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BikeDto>(bike));
        }

        [HttpPost]
        public async Task<ActionResult<BikeDto>> AddBike(BikeDto bikeDto)
        {
            var bikeEntity = _mapper.Map<Bike>(bikeDto);
            _unitOfWork.GetRepository<Bike>().Add(bikeEntity);
            await _unitOfWork.SaveChangesAsync();
            var bikeToReturn = _mapper.Map<BikeDto>(bikeEntity);

            return CreatedAtRoute("GetBikeById", new { id = bikeEntity.Id }, bikeToReturn);
        }

        //[HttpPut]
        //public async Task<ActionResult<BikeDto>> UpdateBike(BikeDto bikeForUpdate)
        //{
        //    var bikeEntity = _mapper.Map<Bike>(bikeForUpdate);
        //    if (bikeEntity.Id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    _unitOfWork.GetRepository<Bike>().Update(bikeEntity);
        //    await _unitOfWork.SaveChangesAsync();
        //    var bikeToReturn = _mapper.Map<BikeForView>(bikeEntity);

        //    return Ok(bikeToReturn);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<BikeForView>> DeleteBike(int id)
        //{
        //    var bike = await _unitOfWork.GetRepository<Bike>().GetByIdAsync(id);
        //    if (bike == null)
        //    {
        //        return NotFound();
        //    }
        //    await _unitOfWork.GetRepository<Bike>().DeleteByIdAsync(bike.Id);

        //    return Ok(_mapper.Map<BikeForView>(bike));
        //}
    }
}
