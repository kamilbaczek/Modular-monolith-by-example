namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser;

using FluentValidation;

public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
{
    public GetUserDetailQueryValidator()
    {
        RuleFor(v => v.PublicId).NotEmpty();
    }
}
