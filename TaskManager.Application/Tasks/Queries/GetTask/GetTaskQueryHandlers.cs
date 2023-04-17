using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using System;

namespace TaskManager.Application.Tasks.Queries.GetTask
{
    public class GetTaskQueryHandlers
  : IRequestHandler<GetTaskQuery, GetTaskDto>
    {
        private readonly ITaskManagerContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskQueryHandlers(ITaskManagerContext dbContext,
           IMapper mapper) =>
           (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetTaskDto> Handle(GetTaskQuery request,
           CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks
                .ProjectTo<GetTaskDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);

            if (task == null)
                throw new Exception("Задача не найдена");

            var sender = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == task.SenderId);
                var receiver = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == task.ReceiverId);

                task.SenderName = sender?.Name + " " + sender?.Surname;
                task.ReceiverName= receiver?.Name + " " + receiver?.Surname;

            return task;
        }
    }
}