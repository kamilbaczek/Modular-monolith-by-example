using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Exceptions;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Events;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items.Services;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries.Common;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries.Common.Fakes;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries;

public class InquiryMadeTests : BaseInquiryTest
{
    [Test]
    public async Task Given_MakeAsync_Then_InquiryIsMade()
    {
        var serviceExistingChecker = SetupServiceExistingChecker(true);
        var client = FakeClient.Create();
        var services = FakeService.Create();

        var inquiry = await Inquiry.MakeAsync(services, client, serviceExistingChecker);

        var @event = GetPublishedEvent<InquiryMadeDomainEvent>(inquiry);
        @event.InquiryId.Should().NotBeNull();
    }

    [Test]
    public async Task Given_MakeAsync_When_InquiryIsEmpty_Then_InquiryCannotBeEmptyException()
    {
        var serviceExistingChecker = SetupServiceExistingChecker(true);
        var client = FakeClient.Create();
        var services = new List<Service>();

        Func<Task> act = () => Inquiry.MakeAsync(services, client, serviceExistingChecker);

        await act.Should().ThrowAsync<InquiryCannotBeEmptyException>();
    }

    [Test]
    public async Task Given_MakeAsync_When_ServicesAreNotExists_Then_ServicesAreNoExistsException()
    {
        var serviceExistingChecker = SetupServiceExistingChecker(false);
        var client = FakeClient.Create();
        var services = FakeService.Create();

        Func<Task> act = () => Inquiry.MakeAsync(services, client, serviceExistingChecker);

        await act.Should().ThrowAsync<InvalidServicesException>();
    }

    private static IServiceExistingChecker SetupServiceExistingChecker(bool areValid)
    {
        var serviceExistingChecker = Substitute.For<IServiceExistingChecker>();
        serviceExistingChecker.ExistAsync(Arg.Any<IReadOnlyCollection<Guid>>())
            .Returns(areValid);

        return serviceExistingChecker;
    }
}
