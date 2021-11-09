using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Sender;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder.Events;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUsersEmails;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose
{
    internal sealed class
        ValuationsCloseToDeadlineRemindEventHandler : INotificationHandler<ValuationCloseToDeadlineRemindEvent>
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

        public async Task Handle(ValuationCloseToDeadlineRemindEvent valuationCloseToDeadlineRemindEvent,
            CancellationToken cancellationToken)
        {
            var query = new GetUsersEmailsQuery();
            var emails = await _userModule.ExecuteQueryAsync(query);

            foreach (var email in emails)
            {
                var request = new ValuationCloseToDeadlineEmailRequest(
                    valuationCloseToDeadlineRemindEvent.DaysBeforeDeadline,
                    email,
                    valuationCloseToDeadlineRemindEvent.ValuationId);

                _valuationCloseToDeadlineMailSender.Send(request);
            }
        }
    }
}