namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved;

using Messages;
using NServiceBus;
using Sender;
using Users.Application.Contracts;
using Users.Application.Users.Queries.GetUserEmail;

internal sealed class ProposalApprovedEventHandler : IHandleMessages<ProposalApproved>
{
    private readonly IUserModule _userModule;
    private readonly IValuationProposalApprovedMailSender _valuationProposalApprovedMailSender;

    public ProposalApprovedEventHandler(IValuationProposalApprovedMailSender valuationProposalApprovedMailSender,
        IUserModule userModule)
    {
        _valuationProposalApprovedMailSender = valuationProposalApprovedMailSender;
        _userModule = userModule;
    }

    public async Task Handle(ProposalApproved proposalApproved, IMessageHandlerContext context)
    {
        var employeeId = proposalApproved.SuggestedBy;
        var query = new GetUserEmailQuery(employeeId);
        var suggestedByEmployeeEmail = await _userModule.ExecuteQueryAsync(query);

        var request = new ValuationProposalApprovedEmailRequest(
            suggestedByEmployeeEmail,
            proposalApproved.ValuationId,
            proposalApproved.ProposalId,
            proposalApproved.Currency,
            proposalApproved.Value);

        _valuationProposalApprovedMailSender.Send(request);
    }
}
