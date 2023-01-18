namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders;

using Domain.Valuations;
using Domain.Valuations.States;
using Proposals;

internal sealed class ValuationRequestedBuilder
{
    private static InquiryId InquiryId { get; set; }

    internal ValuationRequestedBuilder() => 
        InquiryId = InquiryId.Create();

    private static ValuationRequested Build() => 
        ValuationRequested.Request(InquiryId);

    internal ValuationSuggestedBuilder WithProposal()
    {
        var valuationRequested = Build();
        return new ValuationSuggestedBuilder(valuationRequested);
    }

    public static implicit operator ValuationRequested(ValuationRequestedBuilder requestedBuilder) => 
        Build();
}
