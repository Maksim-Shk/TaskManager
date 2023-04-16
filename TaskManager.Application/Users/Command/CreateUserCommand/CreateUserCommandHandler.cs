using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using TaskManager.Domain;
using System;

namespace TaskManager.Application.Users.Commands.CreateUserCommand
{
    public class GetTaskListQueryHandlers
        : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ITaskManagerContext _dbContext;

        public GetTaskListQueryHandlers(ITaskManagerContext dbContext) =>
           _dbContext = dbContext;

        public async Task<int> Handle(CreateUserCommand request,
           CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Status = UserStatusEnum.Active,
                CreationDate = DateTime.UtcNow,
                LastChangeDate = DateTime.UtcNow
            };
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.UserId;
        }
    }
}