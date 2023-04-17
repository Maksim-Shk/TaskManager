using System;
using MediatR;

namespace TaskManager.Application.Tasks.Commands.UpdateTaskCommand
{
    public class UpdateTaskCommand : IRequest
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int ReceiverId { get; set; }

    }
}
