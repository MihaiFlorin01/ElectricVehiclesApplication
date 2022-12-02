using Abstractions;
using AutoMapper;
using Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewUserDto>>> GetUsers()
        {
            var users = await _unitOfWork.GetRepository<User>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewUserDto>>(users.Where(x => x.IsDeleted == false)));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<ViewUserDto>> GetUserById(int id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
            if (user == null || user.IsDeleted == true)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ViewUserDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult<ViewUserDto>> AddUser(CreateUserDto createUserDto)
        {
            var userEntity = _mapper.Map<User>(createUserDto);
            _unitOfWork.GetRepository<User>().Add(userEntity);
            await _unitOfWork.SaveChangesAsync();
            var userToReturn = _mapper.Map<ViewUserDto>(userEntity);

            return CreatedAtRoute("GetUserById", new { id = userEntity.Id }, userToReturn);
        }

        [HttpPut]
        public async Task<ActionResult<ViewUserDto>> UpdateUser(UpdateUserDto updateUserDto)
        {
            var userEntity = _mapper.Map<User>(updateUserDto);
            if (userEntity.Id <= 0)
            {
                return BadRequest();
            }
            _unitOfWork.GetRepository<User>().Update(userEntity);
            await _unitOfWork.SaveChangesAsync();
            var userToReturn = _mapper.Map<ViewUserDto>(userEntity);

            return Ok(userToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewUserDto>> DeleteUser(int id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _unitOfWork.GetRepository<User>().DeleteByIdAsync(user.Id);
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<ViewUserDto>(user));

        }
    }
}
