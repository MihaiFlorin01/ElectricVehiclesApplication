//using AutoMapper;
//using Domain.Entities;
//using Domain.Models.CustomerModels;
//using Microsoft.AspNetCore.Mvc;
//using Persistence.Repositories.CustomerRepositories;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomersController : ControllerBase
//    {
//        private readonly ICustomerRepository _customerRepository;
//        private readonly IMapper _mapper;

//        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
//        {
//            _customerRepository= customerRepository;
//            _mapper= mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<CustomerForView>>> GetCustomers()
//        {
//            var customers = await _customerRepository.GetCustomersAsync();

//            return Ok(_mapper.Map<IEnumerable<CustomerForView>>(customers));
//        }

//        [HttpGet("{id}", Name = "GetCustomerById")]
//        public async Task<ActionResult<CustomerForView>> GetCustomerById(int id)
//        {
//            var customer = await _customerRepository.GetCustomerByIdAsync(id);

//            return Ok(_mapper.Map<CustomerForView>(customer));
//        }

//        [HttpPost]
//        public async Task<ActionResult<CustomerForView>> AddCustomer(CustomerForCreation customerForCreation)
//        {
//            var customerEntity = _mapper.Map<Customer>(customerForCreation);
//            _customerRepository.AddCustomer(customerEntity);
//            await _customerRepository.SaveChangesAsync();
//            var customerToReturn = _mapper.Map<CustomerForView>(customerEntity);

//            return CreatedAtRoute("GetCustomerById", new {id = customerEntity.Id}, customerToReturn);
//        }

//        [HttpPut]
//        public async Task<ActionResult<CustomerForView>> UpdateCustomer(CustomerForUpdate customerForUpdate)
//        {
//            var customerEntity = _mapper.Map<Customer>(customerForUpdate);
//            if (customerEntity.Id <= 0)
//            {
//                return BadRequest();
//            }
//            _customerRepository.UpdateCustomer(customerEntity);
//            await _customerRepository.SaveChangesAsync();
//            var customerToReturn = _mapper.Map<CustomerForView>(customerEntity);

//            return Ok(customerToReturn);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<CustomerForView>> DeleteCustomer(int id)
//        {
//            var customer = await _customerRepository.GetCustomerByIdAsync(id);
//            if (customer == null)
//            {
//                return NotFound();
//            }
//            _customerRepository.DeleteCustomer(customer);
//            await _customerRepository.SaveChangesAsync();

//            return Ok(_mapper.Map<CustomerForView>(customer));
//        }
//    }
//}
