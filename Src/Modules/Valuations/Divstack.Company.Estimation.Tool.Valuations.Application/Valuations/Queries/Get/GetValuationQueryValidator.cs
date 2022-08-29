namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get;

using FluentValidation;

public sealed class GetValuationQueryValidator : AbstractValidator<GetValuationQuery>
{
    public GetValuationQueryValidator() =>
        RuleFor(query => query.ValuationId).NotEmpty();
}
