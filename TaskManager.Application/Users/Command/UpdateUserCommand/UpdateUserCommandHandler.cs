using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManager.Application.Users.Commands.UpdateUserCommand
{
    public class GetTaskListQueryHandlers
        : IRequestHandler<UpdateUserCommand>
    {
        private readonly ITaskManagerContext _dbContext;

        public GetTaskListQueryHandlers(ITaskManagerContext dbContext) =>
           _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserCommand request,
           CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.CreationDate = request.CreationDate.ToUniversalTime();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}