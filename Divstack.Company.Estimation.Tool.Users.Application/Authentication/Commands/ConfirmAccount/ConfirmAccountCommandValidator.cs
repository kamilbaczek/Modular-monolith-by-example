using Divstack.Company.Estimation.Tool.Users.Application.Common.Extensions.Validations;
using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.ConfirmAccount
{
    public class ConfirmAccountCommandValidator : AbstractValidator<ConfirmAccountCommand>
    {
        public ConfirmAccountCommandValidator()
        {
            RuleFor(p => p.Password)
                .NotEmpty()
                .MustBeCorrectPasswordFormat();

            RuleFor(p => p.Token).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}