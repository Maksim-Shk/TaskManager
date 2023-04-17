using AutoMapper;
using EnumsNET;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Tasks.Queries.GetTaskList;
using TaskManager.Application.Tasks.Queries.GetUserTaskList;
using TaskManager.Domain;
namespace TaskManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ITaskManagerContext _dbContext;

        public StatusController(
           IMapper mapper, ITaskManagerContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<string?>>> GetTaskStatus()
        {
            return Enum.GetValues(typeof(TaskStatusEnum))
                .Cast<TaskStatusEnum>()
                .Select(v => v.AsString(EnumFormat.Description))
                .ToList();
            //@((TaskStatusEnum)dto.Status).AsString(EnumFormat.Description)))
        }
    }
}
