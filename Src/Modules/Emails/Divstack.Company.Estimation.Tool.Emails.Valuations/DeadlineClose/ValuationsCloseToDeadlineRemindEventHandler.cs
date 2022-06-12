namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose;

using NServiceBus;
using Reminders.Valuations.DeadlineClose.Reminder.Events;
using Sender;
using Users.Application.Contracts;
using Users.Application.Users.Queries.GetUsersEmails;

public sealed class
    ValuationsCloseToDeadlineRemindEventHandler : IHandleMessages<ValuationCloseToDeadlineRemind>
{
    private readonly IUserModule _userModule;
    private readonly IValuationCloseToDeadlineMailSender _valuationCloseToDeadlineMailSender;

    internal ValuationsCloseToDeadlineRemindEventHandler(
        IValuationCloseToDeadlineMailSender valuationCloseToDeadlineMailSender,
        IUserModule userModule)
    {
        _valuationCloseToDeadlineMailSender = valuationCloseToDeadlineMailSender;
        _userModule = userModule;
    }

    public async Task Handle(ValuationCloseToDeadlineRemind valuationCloseToDeadlineRemind, IMessageHandlerContext context)
    {
        var query = new GetUsersEmailsQuery();
        var emails = await _userModule.ExecuteQueryAsync(query);

        foreach (var email in emails)
        {
            var request = new ValuationCloseToDeadlineEmailRequest(
                valuationCloseToDeadlineRemind.DaysBeforeDeadline,
                email,
                valuationCloseToDeadlineRemind.ValuationId);

            _valuationCloseToDeadlineMailSender.Send(request);
        }
    }
}
