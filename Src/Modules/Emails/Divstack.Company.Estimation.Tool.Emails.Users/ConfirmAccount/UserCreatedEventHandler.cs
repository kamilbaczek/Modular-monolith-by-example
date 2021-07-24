using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Sender;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.CreateUser;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount
{
    internal sealed class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly IConfirmAccountMailSender _confirmAccountMailSender;

        public UserCreatedEventHandler(IConfirmAccountMailSender confirmAccountMailSender)
        {
            _confirmAccountMailSender = confirmAccountMailSender;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
             _confirmAccountMailSender.Send(
                notification.Email,
                notification.ConfirmAccountToken,
                notification.UserPublicId);

             return Task.CompletedTask;
        }
    }
}
