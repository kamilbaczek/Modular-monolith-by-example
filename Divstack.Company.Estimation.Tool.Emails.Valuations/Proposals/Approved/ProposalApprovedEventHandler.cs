using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Sender;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserEmail;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved
{
    internal sealed class ProposalApprovedEventHandler : INotificationHandler<ProposalApprovedEvent>
    {
        private readonly IValuationProposalApprovedMailSender _valuationProposalApprovedMailSender;
        private readonly IUserModule _userModule;

        public ProposalApprovedEventHandler(IValuationProposalApprovedMailSender valuationProposalApprovedMailSender,
            IUserModule userModule)
        {
            _valuationProposalApprovedMailSender = valuationProposalApprovedMailSender;
            _userModule = userModule;
        }

        public async Task Handle(ProposalApprovedEvent proposalApprovedEvent, CancellationToken cancellationToken)
        {
            var employeeId = proposalApprovedEvent.SuggestedBy.Value;
            var query = new GetUserEmailQuery(employeeId);
            var suggestedByEmployeeEmail = await _userModule.ExecuteQueryAsync(query);

            var request = new ValuationProposalApprovedEmailRequest(
                suggestedByEmployeeEmail,
                proposalApprovedEvent.ValuationId.Value,
                proposalApprovedEvent.ProposalId.Value,
                proposalApprovedEvent.Value);

            await _valuationProposalApprovedMailSender.SendEmailAsync(request);
        }
    }
}
