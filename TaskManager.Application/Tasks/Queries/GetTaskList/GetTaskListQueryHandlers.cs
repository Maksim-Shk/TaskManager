using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace TaskManager.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandlers
  : IRequestHandler<GetTaskListQuery, TaskListViewModel>
    {
        private readonly ITaskManagerContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandlers(ITaskManagerContext dbContext,
           IMapper mapper) =>
           (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskListViewModel> Handle(GetTaskListQuery request,
           CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.Tasks
                .ProjectTo<TaskListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var task in tasks)
            {
                var sender = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == task.SenderId);
                var receiver = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == task.ReceiverId);
                task.SenderName = sender?.Name + " " + sender?.Surname;
                task.ReceiverName= receiver?.Name + " " + receiver?.Surname;
            }

            return new TaskListViewModel { Tasks = tasks };
        }
    }
}