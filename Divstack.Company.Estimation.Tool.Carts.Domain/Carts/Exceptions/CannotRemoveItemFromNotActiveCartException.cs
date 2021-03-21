using System;

namespace Divstack.Company.Estimation.Tool.Carts.Domain.Carts.Exceptions
{
    public sealed class CannotRemoveItemFromNotActiveCartException : Exception
    {
        private const string CannotAddItemToNotActiveCartMessage = "Cannot remove product from not active cart";

        public CannotRemoveItemFromNotActiveCartException() : base(CannotAddItemToNotActiveCartMessage)
        {
        }
    }
}