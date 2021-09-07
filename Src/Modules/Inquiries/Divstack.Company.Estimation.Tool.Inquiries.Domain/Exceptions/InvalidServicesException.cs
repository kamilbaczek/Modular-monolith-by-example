using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Exceptions
{
    public sealed class InvalidServicesException : InvalidOperationException
    {
        public InvalidServicesException(IList<ServiceId> productIds) :
            base($"Not all services exist: {string.Join(',', productIds)}")
        {
        }
    }
}