using System;
using MediatR;

namespace TaskManager.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
