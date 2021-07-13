using System;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.CreateUser
{
    public sealed class UserCreatedEvent : INotification
    {
        private UserCreatedEvent(
            Guid userPublicId,
            string email,
            string userName,
            string confirmAccountToken)
        {
            UserPublicId = userPublicId;
            Email = email;
            UserName = userName;
            ConfirmAccountToken = confirmAccountToken;
        }

        public Guid UserPublicId { get; }
        public string Email { get; }
        public string UserName { get; }
        public string ConfirmAccountToken { get; }

        public static UserCreatedEvent Create(
            Guid userPublicId,
            string email,
            string userName,
            string confirmAccountToken)
        {
            return new UserCreatedEvent(
                userPublicId,
                email,
                userName,
                confirmAccountToken);
        }
    }
}