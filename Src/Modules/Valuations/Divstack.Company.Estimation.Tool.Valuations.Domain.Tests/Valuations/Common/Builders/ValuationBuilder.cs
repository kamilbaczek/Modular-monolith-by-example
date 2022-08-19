namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders;

using Domain.Valuations;
using Proposals;

internal sealed class ValuationBuilder
{
    internal ValuationBuilder() => InquiryId = InquiryId.Create();
    private static InquiryId InquiryId { get; set; }


    private static Valuation Build() =>
        Valuation.Request(InquiryId);

    internal ProposalSuggestionBuilder WithProposal()
    {
        var valuation = Build();
        return new ProposalSuggestionBuilder(valuation);
    }

    public static implicit operator Valuation(ValuationBuilder builder) =>
        Build();
}
