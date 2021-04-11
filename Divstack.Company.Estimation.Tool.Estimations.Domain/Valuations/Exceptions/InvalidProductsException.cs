using System;
using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions
{
    public sealed class InvalidProductsException : InvalidOperationException
    {
        public InvalidProductsException(IList<ProductId>  productIds) :
            base($"Not all products exist: {string.Join(',',productIds)}")
        {}
    }
}