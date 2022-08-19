namespace Divstack.Company.Estimation.Tool.Emails.Priorities.DeadlineClose;

using NServiceBus;
using Reminders.Priorities.DeadlineClose.Reminder.Events;
using Sender;
using Users.Application.Contracts;
using Users.Application.Users.Queries.GetUsersEmails;

internal sealed class
    PriorityCloseToDeadlineRemindEventHandler : IHandleMessages<PriorityCloseToDeadlineRemind>
{
    private readonly IPriorityCloseToDeadlineMailSender _priorityCloseToDeadlineMailSender;
    private readonly IUserModule _userModule;

    internal PriorityCloseToDeadlineRemindEventHandler(
        IPriorityCloseToDeadlineMailSender priorityCloseToDeadlineMailSender,
        IUserModule userModule)
    {
        _priorityCloseToDeadlineMailSender = priorityCloseToDeadlineMailSender;
        _userModule = userModule;
    }

    public async Task Handle(PriorityCloseToDeadlineRemind priorityCloseToDeadlineRemind, IMessageHandlerContext context)
    {
        var query = new GetUsersEmailsQuery();
        var emails = await _userModule.ExecuteQueryAsync(query);

        foreach (var email in emails)
        {
            var request = new PriorityCloseToDeadlineEmailRequest(
                priorityCloseToDeadlineRemind.DaysBeforeDeadline,
                email,
                priorityCloseToDeadlineRemind.ValuationId);

            _priorityCloseToDeadlineMailSender.Send(request);
        }
    }
}
