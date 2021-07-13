using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordCommandValidator()
        {
            RuleFor(command => command.PublicId).NotEmpty();
            RuleFor(command => command.NewPassword).MaximumLength(255).NotEmpty();
        }
    }
}