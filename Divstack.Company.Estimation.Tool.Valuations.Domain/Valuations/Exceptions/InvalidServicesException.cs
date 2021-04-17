using System;
using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions
{
    public sealed class InvalidServicesException : InvalidOperationException
    {
        public InvalidServicesException(IList<ServiceId>  productIds) :
            base($"Not all services exist: {string.Join(',',productIds)}")
        {}
    }
}
