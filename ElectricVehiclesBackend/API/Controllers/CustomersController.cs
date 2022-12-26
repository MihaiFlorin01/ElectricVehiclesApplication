using Abstractions;
using AutoMapper;
using Dtos.CustomerDtos;
using Dtos.VehicleDtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewCustomerDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewCustomerDto>>> GetCustomers()
        {
            var customers = await _unitOfWork.GetRepository<Customer>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewCustomerDto>>(customers));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewCustomerDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<ActionResult<ViewCustomerDto>> GetCustomerById(int id)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ViewCustomerDto>(customer));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewCustomerDto), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ViewCustomerDto>> AddCustomer(CreateCustomerDto createCustomerDto)
        {
            var customerEntity = _mapper.Map<Customer>(createCustomerDto);
           
            _unitOfWork.GetRepository<Customer>().Add(customerEntity);

            await _unitOfWork.SaveChangesAsync();
           
            var customerToReturn = _mapper.Map<ViewCustomerDto>(customerEntity);

            return CreatedAtRoute("GetCustomerById", new { id = customerEntity.Id }, customerToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewCustomerDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<ViewCustomerDto>> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var customerEntity = _mapper.Map<Customer>(updateCustomerDto);

            _unitOfWork.GetRepository<Customer>().Update(customerEntity);

            await _unitOfWork.SaveChangesAsync();

            var customerToReturn = _mapper.Map<ViewCustomerDto>(customerEntity);

            return Ok(customerToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewCustomerDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewCustomerDto>> DeleteCustomer(int id)
        {
            var customerEntity = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(id);

            if (customerEntity == null)
            {
                return NotFound();
            }

            await _unitOfWork.GetRepository<Customer>().DeleteByIdAsync(id);

            await _unitOfWork.SaveChangesAsync();

            var customerToReturn = _mapper.Map<ViewVehicleDto>(customerEntity);

            return Ok(customerToReturn);
        }
    }
}
