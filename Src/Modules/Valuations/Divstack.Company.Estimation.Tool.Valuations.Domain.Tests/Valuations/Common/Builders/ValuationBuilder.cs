namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders;

using Domain.Valuations;
using Domain.Valuations.Deadlines;
using Proposals;

internal sealed class ValuationBuilder
{
    private const int WorksDaysToDeadlineFromNow = 3;

    internal ValuationBuilder()
    {
        InquiryId = InquiryId.Create();
        Deadline = A.Deadline().WithDeadline(WorksDaysToDeadlineFromNow);
    }
    private static InquiryId InquiryId { get; set; }
    private static Deadline Deadline { get; set; }

    internal ValuationBuilder WithDeadline(int worksDaysToDeadlineFromNow)
    {
        Deadline = A.Deadline().WithDeadline(worksDaysToDeadlineFromNow);
        return this;
    }

    private static Valuation Build()
    {
        return Valuation.Request(InquiryId, Deadline);
    }

    internal ProposalSuggestionBuilder WithProposal()
    {
        var valuation = Build();
        return new ProposalSuggestionBuilder(valuation);
    }

    public static implicit operator Valuation(ValuationBuilder builder)
    {
        return Build();
    }
}
