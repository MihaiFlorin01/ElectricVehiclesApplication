using AutoMapper;
using Domain.Entities;
using Domain.Models.BikeModels;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories.BikeRepositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IMapper _mapper;

        public BikeController(IBikeRepository bikeRepository, IMapper mapper)
        {
            _bikeRepository = bikeRepository ?? throw new ArgumentNullException(nameof(bikeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikeForView>>> GetBikes()
        {
            var bikes = await _bikeRepository.GetBikesAsync();

            return Ok(_mapper.Map<IEnumerable<BikeForView>>(bikes));
        }

        [HttpGet("{id}", Name ="GetBikeById")]
        public async Task<ActionResult<BikeForView>> GetBikeById(int id)
        {
            var bike = await _bikeRepository.GetBikeByIdAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BikeForView>(bike));
        }

        [HttpPost]
        public async Task<ActionResult<BikeForView>> AddBike(BikeForCreation bikeForCreation)
        {
            var bikeEntity = _mapper.Map<Bike>(bikeForCreation);
            _bikeRepository.AddBike(bikeEntity);
            await _bikeRepository.SaveChangesAsync();
            var bikeToReturn = _mapper.Map<BikeForView>(bikeEntity);

            return CreatedAtRoute("GetBikeById", new {id = bikeEntity.Id}, bikeToReturn);
        }

        [HttpPut]
        public async Task<ActionResult<BikeForView>> UpdateBike(BikeForUpdate bikeForUpdate)
        {
            var bikeEntity = _mapper.Map<Bike>(bikeForUpdate);
            if (bikeEntity.Id <= 0)
            {
                return BadRequest();
            }
            _bikeRepository.UpdateBike(bikeEntity);
            await _bikeRepository.SaveChangesAsync();
            var bikeToReturn = _mapper.Map<BikeForView>(bikeEntity);

            return Ok(bikeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BikeForView>> DeleteBike(int id)
        {
            var bike = await _bikeRepository.GetBikeByIdAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            _bikeRepository.DeleteBike(bike);
            await _bikeRepository.SaveChangesAsync();

            return Ok(_mapper.Map<BikeForView>(bike));
        }
    }
}
