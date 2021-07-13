using Divstack.Company.Estimation.Tool.Users.Application.Common.Extensions.Validations;
using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.CreateUser
{
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
}