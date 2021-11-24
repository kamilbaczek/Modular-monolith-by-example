namespace Divstack.Company.Estimation.Tool.Emails.Users.ConfirmAccount;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sender;
using Tool.Users.Application.Users.Commands.CreateUser;

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
