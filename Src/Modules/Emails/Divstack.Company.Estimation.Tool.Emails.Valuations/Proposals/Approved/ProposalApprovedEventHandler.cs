using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Sender;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserEmail;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved
{
    internal sealed class ProposalApprovedEventHandler : INotificationHandler<ProposalApproved>
    {
        private readonly IUserModule _userModule;
        private readonly IValuationProposalApprovedMailSender _valuationProposalApprovedMailSender;

        public ProposalApprovedEventHandler(IValuationProposalApprovedMailSender valuationProposalApprovedMailSender,
            IUserModule userModule)
        {
            _valuationProposalApprovedMailSender = valuationProposalApprovedMailSender;
            _userModule = userModule;
        }

        public async Task Handle(ProposalApproved proposalApprovedDomainEvent, CancellationToken cancellationToken)
        {
            var employeeId = proposalApprovedDomainEvent.SuggestedBy;
            var query = new GetUserEmailQuery(employeeId);
            var suggestedByEmployeeEmail = await _userModule.ExecuteQueryAsync(query);

            var request = new ValuationProposalApprovedEmailRequest(
                suggestedByEmployeeEmail,
                proposalApprovedDomainEvent.ValuationId,
                proposalApprovedDomainEvent.ProposalId,
                proposalApprovedDomainEvent.Currency,
                proposalApprovedDomainEvent.Value);

            _valuationProposalApprovedMailSender.Send(request);
        }
    }
}
