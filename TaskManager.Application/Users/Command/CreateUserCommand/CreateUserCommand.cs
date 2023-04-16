using System;
using MediatR;

namespace TaskManager.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
