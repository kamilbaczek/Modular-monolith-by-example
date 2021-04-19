using System;

namespace Divstack.Company.Estimation.Tool.Carts.Domain.Carts.Exceptions
{
    public sealed class CannotAddItemToNotActiveCartException : Exception
    {
        private const string CannotAddItemToNotActiveCartMessage = "Cannot add product to not active cart";

        public CannotAddItemToNotActiveCartException() : base(CannotAddItemToNotActiveCartMessage)
        {
        }
    }
}