using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace TaskManager.Application.Tasks.Queries.GetUserTaskList
{
    public class GetUserTaskListQueryHandlers
  : IRequestHandler<GetUserTaskListQuery, UserTaskListViewModel>
    {
        private readonly ITaskManagerContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserTaskListQueryHandlers(ITaskManagerContext dbContext,
           IMapper mapper) =>
           (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserTaskListViewModel> Handle(GetUserTaskListQuery request,
           CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.Tasks
                .ProjectTo<UserTaskListDto>(_mapper.ConfigurationProvider)
                .Where(u=>u.SenderId == request.UserId || u.ReceiverId == request.UserId)
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

            return new UserTaskListViewModel { Tasks = tasks };
        }
    }
}