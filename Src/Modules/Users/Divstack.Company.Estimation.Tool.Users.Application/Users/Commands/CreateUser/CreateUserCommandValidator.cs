namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.CreateUser;

using Common.Extensions.Validations;
using FluentValidation;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(255).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(255).NotEmpty();
        RuleFor(x => x.UserName).Username();
        RuleFor(x => x.Email).MaximumLength(255).EmailAddress().NotEmpty();
        RuleFor(x => x.Roles).NotEmpty();
    }
}
