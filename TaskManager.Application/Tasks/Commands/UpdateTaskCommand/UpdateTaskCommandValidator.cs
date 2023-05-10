using FluentValidation;
using System;
using TaskManager.Application.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(command => command.TaskId).GreaterThanOrEqualTo(1);
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Description).NotEmpty();
        RuleFor(command => command.CreationDate).NotNull();
        RuleFor(command => command.ReceiverId).GreaterThanOrEqualTo(1);
    }
}