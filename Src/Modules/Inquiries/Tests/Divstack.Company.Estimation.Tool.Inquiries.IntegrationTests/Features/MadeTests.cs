using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make.Dtos;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Inquiries.IntegrationTests.Common;
using Faker;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Inquiries.IntegrationTests.Features
{
    using static InquiriesTesting;

    public class InquiryMadeTests : InquiriesTestBase
    {
        [Test]
        public async Task
            Given_MadeInquiry_Then_InquiryIsMade()
        {
            await EnsureInquiriesAreEmpty();
            var serviceId = await ServicesSeeder.SeedAsync();
            var makeInquiryCommand = GetFakeMakeInquiryCommand(serviceId);

            var inquiryId = await ExecuteCommandAsync(makeInquiryCommand);

            var inquiryListVm = await ExecuteQueryAsync(new GetAllInquiriesQuery());
            inquiryListVm.Inquiries.Count.Should().Be(1);
            var inquiry = inquiryListVm.Inquiries.First();
            inquiryId.Should().NotBeEmpty();
            inquiry.Should().BeEquivalentTo(makeInquiryCommand, option => option
                .ExcludingMissingMembers());
        }

        private static MakeInquiryCommand GetFakeMakeInquiryCommand(Guid serviceId)
        {
            var makeInquiryCommand = new MakeInquiryCommand
            {
                FirstName = Name.First(),
                LastName = Name.Last(),
                Email = Internet.Email(),
                AskedServiceDtos = new List<AskedServiceDto>
                {
                    new()
                    {
                        Id = serviceId,
                        Attributes = new List<AttributeDto>
                        {
                            new()
                            {
                                AttributeId = Guid.NewGuid(),
                                ValueId = Guid.NewGuid()
                            }
                        }
                    }
                }
            };
            return makeInquiryCommand;
        }

        private static async Task EnsureInquiriesAreEmpty()
        {
            await EnsureInquiriesAre(0);
        }

        private static async Task EnsureInquiriesAre(int count)
        {
            var inquiryListVm = await ExecuteQueryAsync(new GetAllInquiriesQuery());
            inquiryListVm.Inquiries.Count.Should().Be(count);
        }
    }
}