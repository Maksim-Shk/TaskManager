using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Users.Commands.CreateUserCommand;
using TaskManager.Application.Users.Commands.UpdateUserCommand;
using TaskManager.Application.Users.Queries.GetUserInfo;
using TaskManager.Application.Users.Queries.GetUserList;
using TaskManager.Domain;

namespace TaskManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ITaskManagerContext _dbContext;

        public UserController(
           IMapper mapper, ITaskManagerContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            command.UserId = updateUserDto.UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<int>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        [HttpGet("UserList")]
        public async Task<ActionResult<List<UserListDto>>> GetUserList()
        {
            var query = new GetUserListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("UserInfo/{id}")]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo(int id)
        {
            var query = new GetUserInfoQuery
            {
                UserId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
