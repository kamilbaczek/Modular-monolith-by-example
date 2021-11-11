using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items.Services;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries.Common.Fakes
{
    internal static class FakeService
    {
        internal static List<Service> Create()
        {
            var service = Service.Create(new Guid());
            var services = new List<Service> {service};

            return services;
        }
    }
}