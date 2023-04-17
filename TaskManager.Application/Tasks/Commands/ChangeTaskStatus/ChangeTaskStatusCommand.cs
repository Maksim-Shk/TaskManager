using MediatR;
using TaskManager.Domain;

namespace TaskManager.Application.Tasks.Commands.ChangeTaskStatus
{
    public class ChangeTaskStatusCommand : IRequest
    {
        public int TaskId { get; set; }
        public TaskStatusEnum Status { get; set; }

    }
}
