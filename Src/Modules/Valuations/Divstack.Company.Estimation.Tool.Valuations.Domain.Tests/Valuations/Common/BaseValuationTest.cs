namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;

using Domain.Valuations;
using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using Shared.DDD.BuildingBlocks.Tests;
using Shared.DDD.ValueObjects;

public abstract class BaseValuationTest : BaseTest
{
    protected static ProposalId SuggestFakeProposal(EmployeeId employee, Valuation valuation)
    {
        var money = Money.Of(30, "USD");
        return SuggestFakeProposal(employee, valuation, money);
    }

    protected static ProposalId SuggestFakeProposal(EmployeeId employee, Valuation valuation, Money money)
    {
        valuation.SuggestProposal(money, "test", employee);
        var @event = GetPublishedEvent<ProposalSuggestedDomainEvent>(valuation);

        return @event.ProposalId;
    }

    private static Valuation RequestFakeValuation(InquiryId inquiry)
    {
        var deadline = FakeDeadline.CreateDeadline();

        return Valuation.Request(inquiry, deadline);
    }

    protected static Valuation RequestFakeValuation()
    {
        var inquiry = InquiryId.Create();
        return RequestFakeValuation(inquiry);
    }
}
