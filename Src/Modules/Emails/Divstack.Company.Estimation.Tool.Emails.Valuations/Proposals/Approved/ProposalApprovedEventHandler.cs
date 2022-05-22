namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved;

using Sender;
using Shared.Infrastructure.EventBus.Subscribe;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;
using Users.Application.Contracts;
using Users.Application.Users.Queries.GetUserEmail;

internal sealed class ProposalApprovedEventHandler : IIntegrationEventHandler<ProposalApproved>
{
    private readonly IUserModule _userModule;
    private readonly IValuationProposalApprovedMailSender _valuationProposalApprovedMailSender;

    public ProposalApprovedEventHandler(IValuationProposalApprovedMailSender valuationProposalApprovedMailSender,
        IUserModule userModule)
    {
        _valuationProposalApprovedMailSender = valuationProposalApprovedMailSender;
        _userModule = userModule;
    }

    public async ValueTask Handle(ProposalApproved proposalApprovedEvent, CancellationToken cancellationToken)
    {
        var employeeId = proposalApprovedEvent.SuggestedBy;
        var query = new GetUserEmailQuery(employeeId);
        var suggestedByEmployeeEmail = await _userModule.ExecuteQueryAsync(query);

        var request = new ValuationProposalApprovedEmailRequest(
            suggestedByEmployeeEmail,
            proposalApprovedEvent.ValuationId,
            proposalApprovedEvent.ProposalId,
            proposalApprovedEvent.Currency,
            proposalApprovedEvent.Value);

        _valuationProposalApprovedMailSender.Send(request);
    }
}
