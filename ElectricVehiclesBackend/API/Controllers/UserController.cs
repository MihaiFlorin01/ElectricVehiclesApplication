using AutoMapper;
using Domain.Entities;
using Domain.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories.UserRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserForView>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserForView>>(users));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserForView>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserForView>(user));
        }

        [HttpPost]
        public async Task<ActionResult<UserForView>> AddUser(UserForCreation userForCreation)
        {
            var userEntity = _mapper.Map<User>(userForCreation);
            _userRepository.AddUser(userEntity);
            await _userRepository.SaveChangesAsync();
            var userToReturn = _mapper.Map<UserForView>(userEntity);

            return CreatedAtRoute("GetUserById", new { id = userEntity.Id }, userToReturn);
        }

        [HttpPut]
        public async Task<ActionResult<UserForView>> UpdateUser(UserForUpdate userForUpdate)
        {
            var userEntity = _mapper.Map<User>(userForUpdate);
            if (userEntity.Id <= 0)
            {
                return BadRequest();
            }
            _userRepository.UpdateUser(userEntity);
            await _userRepository.SaveChangesAsync();
            var userToReturn = _mapper.Map<UserForView>(userEntity);

            return Ok(userToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserForView>> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _userRepository.DeleteUser(user);
            await _userRepository.SaveChangesAsync();

            return Ok(_mapper.Map<UserForView>(user));

        }
    }
}
