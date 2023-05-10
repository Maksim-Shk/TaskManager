using FluentValidation;
using System;

namespace TaskManager.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.UserId).GreaterThanOrEqualTo(1);
            RuleFor(command=>command.Name).NotEmpty();
            RuleFor(command => command.Surname).NotEmpty();
            RuleFor(command => command.CreationDate).NotNull();

        }
    }
}