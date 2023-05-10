using FluentValidation;

namespace TaskManager.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command=>command.Name).NotEmpty();
            RuleFor(command => command.Surname).NotEmpty();
        }
    }
}
