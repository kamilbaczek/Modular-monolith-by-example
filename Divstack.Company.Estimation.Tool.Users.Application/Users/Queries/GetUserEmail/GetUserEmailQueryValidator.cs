using Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser;
using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserEmail
{
    public class GetUserEmailQueryValidator : AbstractValidator<GetUserDetailQuery>
    {
        public GetUserEmailQueryValidator()
        {
            RuleFor(query => query.PublicId).NotEmpty();
        }
    }
}
