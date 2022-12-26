using Abstractions;
using AutoMapper;
using Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Dtos.VehicleDtos;
using System.Net.Mime;

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

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewUserDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewUserDto>>> GetUsers()
        {
            var users = await _unitOfWork.GetRepository<User>().GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ViewUserDto>>(users));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<ViewUserDto>> GetUserById(int id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ViewUserDto>(user));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewUserDto), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ViewUserDto>> AddUser(CreateUserDto createUserDto)
        {
            var userEntity = _mapper.Map<User>(createUserDto);

            _unitOfWork.GetRepository<User>().Add(userEntity);
            
            await _unitOfWork.SaveChangesAsync();
            
            var userToReturn = _mapper.Map<ViewUserDto>(userEntity);

            return CreatedAtRoute("GetUserById", new { id = userEntity.Id }, userToReturn);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<ViewUserDto>> UpdateUser(UpdateUserDto updateUserDto)
        {
            var userEntity = _mapper.Map<User>(updateUserDto);
            
            _unitOfWork.GetRepository<User>().Update(userEntity);
            
            await _unitOfWork.SaveChangesAsync();
            
            var userToReturn = _mapper.Map<ViewUserDto>(userEntity);

            return Ok(userToReturn);
        }


        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
