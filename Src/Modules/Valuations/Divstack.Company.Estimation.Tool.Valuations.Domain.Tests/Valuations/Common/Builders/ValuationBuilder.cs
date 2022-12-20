namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders;

using Domain.Valuations;
using Domain.Valuations.States;
using Proposals;

internal sealed class ValuationBuilder
{
    internal ValuationBuilder() => InquiryId = InquiryId.Create();
    private static InquiryId InquiryId { get; set; }


    private static ValuationRequested Build() =>
        ValuationRequested.Request(InquiryId);

    internal ProposalSuggestionBuilder WithProposal()
    {
        var valuation = Build();
        return new ProposalSuggestionBuilder(valuation);
    }

    public static implicit operator ValuationRequested(ValuationBuilder builder) =>
        Build();
}
