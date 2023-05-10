using FluentValidation;

namespace TaskManager.Application.Tasks.Commands.ChangeTaskReceiver
{
    public class ChangeTaskReceiverCommandValidator : AbstractValidator <ChangeTaskReceiverCommand>
    {
        public ChangeTaskReceiverCommandValidator()
        {
            RuleFor(command => command.TaskId).GreaterThanOrEqualTo(1);
            RuleFor(command => command.ReceiverId).GreaterThanOrEqualTo(1);
        }
    }
}
