using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items.Services;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries.Common;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using NSubstitute;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries
{
    public class InquiryMadeTests : BaseInquiryTest
    {
        [Test]
        public async Task Given_MakeAsync_Then_ValuationIsCreated()
        {
            var serviceExistingChecker = Substitute.For<IServiceExistingChecker>();
            var clientCompany = ClientCompany.Of("10-10", "test");
            var client = Client.Of(Email.Of("test@mail.com"), "test", "test", clientCompany);
            var service = Service.Create(new Guid());
            var services = new List<Service> { service };
            
            var inquiry = await Inquiry.MakeAsync(services, client, serviceExistingChecker);
            
            inquiry.as
        }
    }
}