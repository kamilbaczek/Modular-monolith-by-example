using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById
{
    public sealed class GetValuationProposalsByIdQueryValidator : AbstractValidator<GetValuationProposalsByIdQuery>
    {
        public GetValuationProposalsByIdQueryValidator()
        {
            RuleFor(query => query.ValuationId).NotEmpty();
        }
    }
}
