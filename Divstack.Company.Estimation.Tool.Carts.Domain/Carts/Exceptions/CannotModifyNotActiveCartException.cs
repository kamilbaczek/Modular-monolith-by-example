using System;

namespace Divstack.Company.Estimation.Tool.Carts.Domain.Carts.Exceptions
{
    public sealed class CannotModifyNotActiveCartException : Exception
    {
        private const string CannotModifyNotActiveCartMessage = "Cannot modify not active cart";

        public CannotModifyNotActiveCartException() : base(CannotModifyNotActiveCartMessage)
        {
        }
    }
}