namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Fakes;
using Domain.Inquiries;
using Domain.Inquiries.Events;
using Domain.Inquiries.Exceptions;
using Domain.Inquiries.Items.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Services.Core.Services.Contracts;

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
