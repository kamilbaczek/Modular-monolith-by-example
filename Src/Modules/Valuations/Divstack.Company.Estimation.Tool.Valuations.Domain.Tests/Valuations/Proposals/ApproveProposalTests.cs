namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Exceptions;
using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using Domain.Valuations.States;
using Shared.DDD.BuildingBlocks.Tests;

public class ApproveProposalTests : BaseValuationTest
{
    [Test]
    public void Given_ApproveProposal_Then_ProposalIsApproved()
    {
        var employeeId = new EmployeeId(Guid.NewGuid());
        ValuationNegotiation valuationNegotiation = A.Valuation()
            .WithProposal()
            .WithEmployee(employeeId);
        var proposalSuggestedDomainEvent = valuationNegotiation.GetPublishedEvent<ProposalSuggestedDomainEvent>();

        var valuationApproved = valuationNegotiation.ApproveProposal(proposalSuggestedDomainEvent.ProposalId);

        var @event = GetPublishedEvent<ProposalApprovedDomainEvent>(valuationApproved);
        @event.AssertIsCorrect(proposalSuggestedDomainEvent.ProposalId);
    }
    
    [Test]
    public void Given_ApproveProposal_When_ProposalNotExist_Then_ProposalIsNotFound()
    {
        ValuationNegotiation valuationNegotiation = A.Valuation()
            .WithProposal();
        var proposalId = ProposalId.Create();

        var approveProposal = () => valuationNegotiation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalNotFoundException>();
    }
}
