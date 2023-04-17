using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManager.Application.Tasks.Commands.UpdateTaskCommand
{
    public class UpdateTaskCommandHandler
        : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskManagerContext _dbContext;

        public UpdateTaskCommandHandler(ITaskManagerContext dbContext) =>
           _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTaskCommand request,
           CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks
                .FirstOrDefaultAsync(u => u.TaskId == request.TaskId, cancellationToken);

            if (task == null)
            {
                throw new Exception("Задача не найдена");
            }

            task.Name = request.Name;
            task.Description = request.Description;
            task.ReceiverId = request.ReceiverId;
            task.CreationDate = request.CreationDate; //.ToUniversalTime();
            task.LastChangeDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}