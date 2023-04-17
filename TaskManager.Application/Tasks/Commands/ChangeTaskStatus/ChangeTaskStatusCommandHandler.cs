using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Application.Tasks.Commands.ChangeTaskStatus;

namespace TaskManager.Application.Tasks.Commands.UpdateTaskCommand
{
    public class ChangeTaskStatusCommandHandler
        : IRequestHandler<ChangeTaskStatusCommand>
    {
        private readonly ITaskManagerContext _dbContext;

        public ChangeTaskStatusCommandHandler(ITaskManagerContext dbContext) =>
           _dbContext = dbContext;

        public async Task<Unit> Handle(ChangeTaskStatusCommand request,
           CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks
                .FirstOrDefaultAsync(u => u.TaskId == request.TaskId, cancellationToken);

            if (task == null)
            {
                throw new Exception("Задача не найдена");
            }
            if (task.Status != request.Status)
            {
                task.Status = request.Status;
                task.LastChangeDate = DateTime.Now;
            }
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}