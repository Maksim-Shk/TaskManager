using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Tasks.Queries.GetTaskList;
using TaskManager.Application.Tasks.Queries.GetUserTaskList;
using TaskManager.Application.Tasks.Commands.UpdateTaskCommand;
using TaskManager.Application.Users.Commands.UpdateUserCommand;
using TaskManager.Client.Pages.TaskPage;
using TaskManager.Application.Tasks.Commands.ChangeTaskReceiver;
using TaskManager.Application.Tasks.Queries.GetTask;
using TaskManager.Application.Tasks.Commands.ChangeTaskStatus;

namespace TaskManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ITaskManagerContext _dbContext;

        public TaskController(
           IMapper mapper, ITaskManagerContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet("GetTaskList")]
        public async Task<ActionResult<List<TaskListDto>>> GetTaskList()
        {
            var query = new GetTaskListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("GetUserTaskList/{id}")]
        public async Task<ActionResult<UserTaskListViewModel>> GetUserTaskList(int id)
        {
            var query = new GetUserTaskListQuery
            {
                UserId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("GetTask/{id}")]
        public async Task<ActionResult<GetTaskDto>> GetTask(int id)
        {
            var query = new GetTaskQuery
            {
                TaskId = id
            };
            var dto = await Mediator.Send(query);
            return Ok(dto);
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("ChangeTaskReceiver")]
        public async Task<IActionResult> ChangeTaskReceiver([FromBody] ChangeTaskReceiverDto changeTaskReceiver)
        {
            var command = _mapper.Map<ChangeTaskReceiverCommand>(changeTaskReceiver);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("ChangeTaskStatus")]
        public async Task<IActionResult> ChangeTaskStatus([FromBody] ChangeTaskStatusDto changeTaskReceiver)
        {
            var command = _mapper.Map<ChangeTaskStatusCommand>(changeTaskReceiver);
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
