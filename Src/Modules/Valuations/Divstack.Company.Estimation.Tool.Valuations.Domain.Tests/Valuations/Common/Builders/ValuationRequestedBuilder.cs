namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders;

using Domain.Valuations;
using Domain.Valuations.States;
using Proposals;

internal sealed class ValuationRequestedBuilder
{
    private static InquiryId InquiryId { get; set; }

    internal ValuationRequestedBuilder()
    {
        InquiryId = InquiryId.Create();
    }

    private static ValuationRequested Build()
    {
        return ValuationRequested.Request(InquiryId);
    }

    internal ValuationNegotiationBuilder WithProposal()
    {
        var valuationRequested = Build();
        return new ValuationNegotiationBuilder(valuationRequested);
    }

    public static implicit operator ValuationRequested(ValuationRequestedBuilder requestedBuilder)
    {
        return Build();
    }
}
