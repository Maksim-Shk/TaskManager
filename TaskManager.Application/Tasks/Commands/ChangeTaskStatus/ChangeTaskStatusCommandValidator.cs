using FluentValidation;
using TaskManager.Application.Tasks.Commands.ChangeTaskStatus;

public class ChangeTaskReceiverCommandValidator : AbstractValidator<ChangeTaskStatusCommand>
{
    public ChangeTaskReceiverCommandValidator()
    {
        RuleFor(command => command.TaskId).GreaterThanOrEqualTo(1);
        RuleFor(command => command.Status).IsInEnum();
    }
}