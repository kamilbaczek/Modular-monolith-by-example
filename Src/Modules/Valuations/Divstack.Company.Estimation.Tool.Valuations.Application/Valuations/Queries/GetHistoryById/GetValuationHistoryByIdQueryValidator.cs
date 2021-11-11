using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById;

public sealed class GetValuationHistoryByIdQueryValidator : AbstractValidator<GetValuationHistoryByIdQuery>
{
    public GetValuationHistoryByIdQueryValidator()
    {
        RuleFor(query => query.ValuationId).NotEmpty();
    }
}
