using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManager.Application.Tasks.Commands.ChangeTaskReceiver
{
    public class ChangeTaskReceiverCommandHandler
        : IRequestHandler<ChangeTaskReceiverCommand>
    {
        private readonly ITaskManagerContext _dbContext;

        public ChangeTaskReceiverCommandHandler(ITaskManagerContext dbContext) =>
           _dbContext = dbContext;

        public async Task<Unit> Handle(ChangeTaskReceiverCommand request,
           CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks
                .FirstOrDefaultAsync(t => t.TaskId == request.TaskId, cancellationToken);

            var receiver = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserId == request.ReceiverId, cancellationToken);

            if (task == null)
                throw new Exception("Задача не найдена");

            if (receiver == null)
                throw new Exception("Исполнитель не найден");

            task.TaskId = request.TaskId;
            task.ReceiverId = request.ReceiverId;
            task.LastChangeDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}