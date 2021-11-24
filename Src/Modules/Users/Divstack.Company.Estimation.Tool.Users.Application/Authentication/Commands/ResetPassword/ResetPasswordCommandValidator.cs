namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.ResetPassword;

using Common.Extensions.Validations;
using FluentValidation;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(p => p.NewPassword)
            .NotEmpty()
            //Minimum eight and maximum 25 characters, at least one uppercase letter, one lowercase letter, one number and one special character
            .MustBeCorrectPasswordFormat();

        RuleFor(p => p.Token).NotEmpty();
        RuleFor(p => p.UserId).NotEmpty();
    }
}
