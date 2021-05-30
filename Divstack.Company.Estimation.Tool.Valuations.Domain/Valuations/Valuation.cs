using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations
{
    public sealed class Valuation : Entity, IAggregateRoot
    {
        private Valuation()
        {
        }

        private Valuation(
            IReadOnlyList<ServiceId> serviceIds,
            Client client)
        {
            Id = new ValuationId(Guid.NewGuid());
            Enquiry = Enquiry.Create(this, serviceIds, client);
            RequestedDate = DateTime.Now;
            Proposals = new List<Proposal>();
            Status = ValuationStatus.WaitForProposal;
            AddDomainEvent(new ValuationRequestedEvent(serviceIds, client.Email));
        }

        public ValuationId Id { get; }
        private IList<Proposal> Proposals { get; }
        private ValuationStatus Status { get; set; }
        private IReadOnlyCollection<Proposal> NotCancelledProposals => GetNotCancelledProposals();

        private Proposal ProposalWaitForDecision => NotCancelledProposals
            .SingleOrDefault(proposal => !proposal.HasDecision());

        private Enquiry Enquiry { get; }
        private DateTime RequestedDate { get; }
        private DateTime? CompletedDate { get; set; }
        private EmployeeId CompletedBy { get; set; }

        private bool IsWaitingForDecision => Status == ValuationStatus.WaitForClientDecision;
        private bool IsCompleted => Status == ValuationStatus.Completed;

        public static async Task<Valuation> RequestAsync(
            List<ServiceId> serviceIds,
            Client client,
            IServiceExistingChecker serviceExistingChecker)
        {
            var productsIdsValues = serviceIds.Select(id => id.Value).ToList();
            var areServicesExists = await serviceExistingChecker.ExistAsync(productsIdsValues);
            if (areServicesExists is false)
                throw new InvalidServicesException(serviceIds);

            return new Valuation(serviceIds, client);
        }

        public void SuggestProposal(Money value,
            string description,
            EmployeeId proposedBy)
        {
            if (IsCompleted)
                throw new ValuationCompletedException(Id);
            if (IsWaitingForDecision)
                throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);

            var proposalDescription = ProposalDescription.From(description);
            var proposal = Proposal.Suggest(this, value, proposalDescription, proposedBy);
            Proposals.Add(proposal);
            Status = ValuationStatus.WaitForClientDecision;

            var @event = new ProposalSuggestedEvent(
                Enquiry.ClientFullName,
                proposedBy,
                proposal.Id,
                value,
                Enquiry.ClientEmail,
                proposalDescription,
                Id);
            AddDomainEvent(@event);
        }

        public void ApproveProposal(ProposalId proposalId)
        {
            var proposal = GetProposal(proposalId);
            proposal.Approve();
            var @event = new ProposalApprovedEvent(
                Id,
                proposalId,
                proposal.Price,
                proposal.SuggestedBy);
            Status = ValuationStatus.Approved;
            AddDomainEvent(@event);
        }

        public void RejectProposal(ProposalId proposalId)
        {
            var proposal = GetProposal(proposalId);
            proposal.Reject();
            var @event = new ProposalRejectedEvent(
                Id,
                proposalId,
                proposal.Price,
                Enquiry.ClientEmail);
            Status = ValuationStatus.Rejected;
            AddDomainEvent(@event);
        }

        public void CancelProposal(ProposalId proposalId, EmployeeId employeeId)
        {
            var proposal = GetProposal(proposalId);
            proposal.Cancel(employeeId);
            Status = ValuationStatus.WaitForProposal;
            AddDomainEvent(new ProposalCancelledEvent(employeeId, proposalId));
        }

        public void Complete(EmployeeId employeeId)
        {
            if (IsCompleted)
                throw new ValuationCompletedException(Id);
            if (ProposalWaitForDecision is not null)
                throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);
            if (!NotCancelledProposals.Any())
                throw new CannotCompleteValuationWithNoProposalException(Id);

            Status = ValuationStatus.Completed;
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

        private IReadOnlyCollection<Proposal> GetNotCancelledProposals()
        {
            return Proposals
                .Where(proposal => !proposal.IsCancelled())
                .ToList();
        }
    }
}
