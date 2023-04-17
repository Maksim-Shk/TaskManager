using System;
using MediatR;

namespace TaskManager.Application.Tasks.Commands.ChangeTaskReceiver
{
    public class ChangeTaskReceiverCommand : IRequest
    {
        public int TaskId { get; set; }
        public int ReceiverId { get; set; }

    }
}
