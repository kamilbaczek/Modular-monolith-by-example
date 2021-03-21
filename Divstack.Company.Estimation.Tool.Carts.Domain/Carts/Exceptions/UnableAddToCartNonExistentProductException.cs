using System;

namespace Divstack.Company.Estimation.Tool.Carts.Domain.Carts.Exceptions
{
    public sealed class UnableAddToCartNonExistentProductException : InvalidOperationException
    {
        private const string UnableAddNonExistentProductToCartMessage = "Unable add non existent product to cart";

        public UnableAddToCartNonExistentProductException() : base(UnableAddNonExistentProductToCartMessage)
        {
        }
    }
}
