namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.ConfirmAccount;

using Common.Extensions.Validations;
using FluentValidation;

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
