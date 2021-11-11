using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;

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
