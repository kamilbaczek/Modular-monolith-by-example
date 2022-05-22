namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose;

using MediatR;
using Reminders.Valuations.DeadlineClose.Reminder.Events;
using Sender;
using Shared.Infrastructure.EventBus.Subscribe;
using Users.Application.Contracts;
using Users.Application.Users.Queries.GetUsersEmails;

internal sealed class
    ValuationsCloseToDeadlineRemindEventHandler : IIntegrationEventHandler<ValuationCloseToDeadlineRemind>
{
    private readonly IUserModule _userModule;
    private readonly IValuationCloseToDeadlineMailSender _valuationCloseToDeadlineMailSender;

    public ValuationsCloseToDeadlineRemindEventHandler(
        IValuationCloseToDeadlineMailSender valuationCloseToDeadlineMailSender,
        IUserModule userModule)
    {
        _valuationCloseToDeadlineMailSender = valuationCloseToDeadlineMailSender;
        _userModule = userModule;
    }

    public async ValueTask Handle(ValuationCloseToDeadlineRemind proposalApprovedEvent,
        CancellationToken cancellationToken)
    {
        var query = new GetUsersEmailsQuery();
        var emails = await _userModule.ExecuteQueryAsync(query);

        foreach (var email in emails)
        {
            var request = new ValuationCloseToDeadlineEmailRequest(
                proposalApprovedEvent.DaysBeforeDeadline,
                email,
                proposalApprovedEvent.ValuationId);

            _valuationCloseToDeadlineMailSender.Send(request);
        }
    }
}
