using Abstractions;
using AutoMapper;
using Dtos.CustomerDtos;
using Dtos.RentalDtos;
using Dtos.VehicleDtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RentalsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewRentalDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewRentalDto>>> GetRentals()
        {
            var rentals = await _unitOfWork.GetRepository<Rental>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewRentalDto>>(rentals));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewRentalDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetRentalById")]
        public async Task<ActionResult<ViewRentalDto>> GetRentalById(int id)
        {
            var rental = await _unitOfWork.GetRepository<Rental>().GetByIdAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ViewRentalDto>(rental));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewRentalDto), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ViewRentalDto>> AddRental(CreateRentalDto createRentalDto)
        {
            var rentalEntity = _mapper.Map<Rental>(createRentalDto);

            _unitOfWork.GetRepository<Rental>().Add(rentalEntity);

            await _unitOfWork.SaveChangesAsync();

            var rentalToReturn = _mapper.Map<ViewRentalDto>(rentalEntity);

            return CreatedAtRoute("GetRentalById", new { id = rentalEntity.Id }, rentalToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewRentalDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<ViewRentalDto>> UpdateRental(UpdateRentalDto updateRentalDto)
        {
            var rentalEntity = _mapper.Map<Rental>(updateRentalDto);

            _unitOfWork.GetRepository<Rental>().Update(rentalEntity);

            await _unitOfWork.SaveChangesAsync();

            var rentalToReturn = _mapper.Map<ViewRentalDto>(rentalEntity);

            return Ok(rentalToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewRentalDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewRentalDto>> DeleteRental(int id)
        {
            var rentalEntity = await _unitOfWork.GetRepository<Rental>().GetByIdAsync(id);

            if (rentalEntity == null)
            {
                return NotFound();
            }

            await _unitOfWork.GetRepository<Rental>().DeleteByIdAsync(id);

            await _unitOfWork.SaveChangesAsync();

            var rentalToReturn = _mapper.Map<ViewRentalDto>(rentalEntity);

            return Ok(rentalToReturn);
        }
    }   
}
