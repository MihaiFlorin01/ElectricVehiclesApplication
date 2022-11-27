//using AutoMapper;
//using Domain.Entities;
//using Domain.Models.BikeModels;
//using Domain.Models.BikeTypeModels;
//using Microsoft.AspNetCore.Mvc;
//using Persistence.Repositories.BikeTypeRepository;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BikeTypesController : ControllerBase
//    {
//        private readonly IBikeTypeRepository _bikeTypeRepository;
//        private readonly IMapper _mapper;

//        public BikeTypesController(IBikeTypeRepository bikeTypeRepository, IMapper mapper)
//        {
//            _bikeTypeRepository= bikeTypeRepository ?? throw new ArgumentNullException(nameof(bikeTypeRepository));
//            _mapper= mapper ?? throw new ArgumentNullException(nameof(_mapper));
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<BikeTypeForView>>> GetBikeTypes()
//        {
//            var bikeTypes = await _bikeTypeRepository.GetBikeTypesAsync();

//            return Ok(_mapper.Map<IEnumerable<BikeTypeForView>>(bikeTypes));
//        }

//        [HttpGet("{id}", Name = "GetBikeTypeById")]
//        public async Task<ActionResult<BikeTypeForView>> GetBikeTypeById(int id)
//        {
//            var bikeType = await _bikeTypeRepository.GetBikeTypeByIdAsync(id);
//            if (bikeType == null)
//            {
//                return NotFound();
//            }
//            return Ok(_mapper.Map<BikeTypeForView>(bikeType));
//        }

//        [HttpPost]
//        public async Task<ActionResult<BikeTypeForView>> AddBikeType(BikeTypeForCreation bikeTypeForCreation)
//        {
//            var bikeTypeEntity = _mapper.Map<BikeType>(bikeTypeForCreation);
//            _bikeTypeRepository.AddBikeType(bikeTypeEntity);
//            await _bikeTypeRepository.SaveChangesAsync();
//            var bikeTypeToReturn = _mapper.Map<BikeTypeForView>(bikeTypeEntity);

//            return CreatedAtRoute("GetBikeTypeById", new { id = bikeTypeEntity.Id }, bikeTypeToReturn);
//        }

//        [HttpPut]
//        public async Task<ActionResult<BikeTypeForView>> UpdateBikeType(BikeTypeForUpdate bikeTypeForUpdate)
//        {
//            var bikeTypeEntity = _mapper.Map<BikeType>(bikeTypeForUpdate);
//            if (bikeTypeEntity.Id <= 0)
//            {
//                return BadRequest();
//            }
//            _bikeTypeRepository.UpdateBikeType(bikeTypeEntity);
//            await _bikeTypeRepository.SaveChangesAsync();
//            var bikeTypeToReturn = _mapper.Map<BikeTypeForView>(bikeTypeEntity);

//            return Ok(bikeTypeToReturn);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<BikeTypeForView>> DeleteBikeType(int id)
//        {
//            var bikeType = await _bikeTypeRepository.GetBikeTypeByIdAsync(id);
//            if (bikeType == null)
//            {
//                return NotFound();
//            }
//            _bikeTypeRepository.DeleteBikeType(bikeType);
//            await _bikeTypeRepository.SaveChangesAsync();

//            return Ok(_mapper.Map<BikeTypeForView>(bikeType));

//        }
//    }
//}
