using System;
using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations
{
    public sealed class Valuation : Entity, IAggregateRoot
    {
        private ValuationId Id { get; }
        private IList<Proposal> Proposals { get; }
        private IEnumerable<Proposal> NotCancelledProposals => GetNotCancelledProposals();
        private Proposal ProposalWaitForDecision => NotCancelledProposals
                                                    .SingleOrDefault(proposal => !proposal.HasDecision());
        private DateTime RequestedDate { get; }
        private DateTime? CompletedDate { get; set; }
        private EmployeeId CompletedBy { get; set; }
        private bool IsCompleted => CompletedDate.HasValue;

        private Valuation(
            IReadOnlyList<ProductId> productsIds,
            Client client)
        {
            Id = new ValuationId(Guid.NewGuid());
            Enquiry.Create(this, productsIds, client);
            RequestedDate = DateTime.Now;
            Proposals = new List<Proposal>();
            AddDomainEvent(new ValuationRequestedEvent(productsIds, client.Email));
        }

        public static Valuation Request(
            List<ProductId> productsIds,
            Client client)
        {
            return new(productsIds, client);
        }

        public void SuggestProposal(Money value,
            string description,
            EmployeeId estimatedBy)
        {
            if (IsCompleted)
                throw new ValuationCompletedException(Id);
            if (ProposalWaitForDecision is not null)
                throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);

            var proposalDescription = ProposalDescription.From(description);
            var proposal = Proposal.Suggest(value, proposalDescription, estimatedBy);
            Proposals.Add(proposal);
        }

        public void ApproveProposal(ProposalId proposalId)
        {
            var proposal = GetProposal(proposalId);
            proposal.Approve();
        }

        public void RejectProposal(ProposalId proposalId, string rejectReason)
        {
            var proposal = GetProposal(proposalId);
            proposal.Reject(rejectReason);
        }

        public void CancelProposal(ProposalId proposalId, EmployeeId employeeId)
        {
            var proposal = GetProposal(proposalId);
            proposal.Cancel(employeeId);
        }

        public void Complete(EmployeeId employeeId)
        {
            if (IsCompleted)
                throw new ValuationCompletedException(Id);
            if (ProposalWaitForDecision is not null)
                throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);
            if (!NotCancelledProposals.Any())
               throw new CannotCompleteValuationWithNoProposalException(Id);
            CompletedBy = employeeId;
            CompletedDate = DateTime.Now;
            AddDomainEvent(new ValuationCompletedEvent(employeeId, Id));
        }

        private Proposal GetProposal(ProposalId proposalId)
        {
            var proposal = NotCancelledProposals.SingleOrDefault(proposal => proposal.Id == proposalId);
            if (proposal is null)
                throw new ProposalNotFoundException(proposalId);
            return proposal;
        }

        private IEnumerable<Proposal> GetNotCancelledProposals()
        {
            return Proposals
                .Where(proposal => !proposal.IsCancelled())
                .ToList();
        }
    }
}
