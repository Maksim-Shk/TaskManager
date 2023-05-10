using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Application.Common.Exceptions;
using TaskManager.Domain;

namespace TaskManager.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand>
    {
        private readonly ITaskManagerContext _dbContext;

        public UpdateUserCommandHandler(ITaskManagerContext dbContext) =>
           _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserCommand request,
           CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.CreationDate = request.CreationDate; //.ToUniversalTime(); //.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
            user.LastChangeDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}