using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations
{
    public sealed class Valuation : Entity, IAggregateRoot
    {
        public ValuationId Id { get; }
        private IList<Proposal> Proposals { get; }
        private IEnumerable<Proposal> NotCancelledProposals => GetNotCancelledProposals();
        private Proposal ProposalWaitForDecision => NotCancelledProposals
                                                    .SingleOrDefault(proposal => !proposal.HasDecision());
        private Enquiry Enquiry { get; }
        private DateTime RequestedDate { get; }
        private DateTime? CompletedDate { get; set; }
        private EmployeeId CompletedBy { get; set; }
        private bool IsCompleted => CompletedDate.HasValue;

        private Valuation()
        {
        }

        private Valuation(
            IReadOnlyList<ProductId> productsIds,
            Client client)
        {
            Id = new ValuationId(Guid.NewGuid());
            Enquiry = Enquiry.Create(this, productsIds, client);
            RequestedDate = DateTime.Now;
            Proposals = new List<Proposal>();
            AddDomainEvent(new ValuationRequestedEvent(productsIds, client.Email));
        }

        public static async Task<Valuation> RequestAsync(
            List<ProductId> productsIds,
            Client client,
            IProductExistingChecker productExistingChecker)
        {
            var productsIdsValues = productsIds.Select(id => id.Value).ToList();
            var areProductsExists = await productExistingChecker.ExistAsync(productsIdsValues);
            if (areProductsExists is false)
                throw new InvalidProductsException(productsIds);

            return new Valuation(productsIds, client);
        }

        public void SuggestProposal(Money value,
            string description,
            EmployeeId proposedBy)
        {
            if (IsCompleted)
                throw new ValuationCompletedException(Id);
            if (ProposalWaitForDecision is not null)
                throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);

            var proposalDescription = ProposalDescription.From(description);
            var proposal = Proposal.Suggest(this, value, proposalDescription, proposedBy);
            Proposals.Add(proposal);
            AddDomainEvent(new ProposalSuggestedEvent(proposedBy, value, proposal.Id));
        }

        public void ApproveProposal(ProposalId proposalId)
        {
            var proposal = GetProposal(proposalId);
            proposal.Approve();
            AddDomainEvent(new ProposalApprovedEvent(proposalId, Enquiry.ClientEmail));
        }

        public void RejectProposal(ProposalId proposalId, string rejectReason)
        {
            var proposal = GetProposal(proposalId);
            proposal.Reject(rejectReason);
            AddDomainEvent(new ProposalRejectedEvent(rejectReason, proposalId, Enquiry.ClientEmail));

        }

        public void CancelProposal(ProposalId proposalId, EmployeeId employeeId)
        {
            var proposal = GetProposal(proposalId);
            proposal.Cancel(employeeId);
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
