namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.ExchangeRefreshToken;

using FluentValidation;

public class ExchangeRefreshTokenCommandValidator : AbstractValidator<ExchangeRefreshTokenCommand>
{
    public ExchangeRefreshTokenCommandValidator()
    {
        RuleFor(x => x.RefreshToken).NotNull().NotEmpty();
        RuleFor(x => x.Token).NotNull().NotEmpty();
    }
}
