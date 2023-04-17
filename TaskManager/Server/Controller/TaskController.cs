using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Tasks.Queries.GetTaskList;
using TaskManager.Application.Tasks.Queries.GetUserTaskList;

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
        public async Task<ActionResult<List<TaskListDto>>> SubdivisionGet()
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
    }
}
