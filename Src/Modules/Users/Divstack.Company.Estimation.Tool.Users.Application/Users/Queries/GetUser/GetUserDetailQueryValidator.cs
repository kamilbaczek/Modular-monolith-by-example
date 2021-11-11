using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser;

public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
{
    public GetUserDetailQueryValidator()
    {
        RuleFor(v => v.PublicId).NotEmpty();
    }
}
