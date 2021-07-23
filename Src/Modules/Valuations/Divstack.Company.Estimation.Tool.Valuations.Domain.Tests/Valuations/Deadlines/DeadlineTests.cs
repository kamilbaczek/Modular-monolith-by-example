using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Deadlines
{
    // public class DeadlineTests : BaseValuationTest
    // {
    //
    //     private static object[] _datesTestCases =
    //     {
    //         new object[] { new DateTime(1998, 2, 3), 3, true },
    //         new object[] { new DateTime(2021, 6, 25), 2, false },
    //     };
    //
    //     [Test, TestCaseSource(nameof(_datesTestCases))]
    //     public void Given_Create_Then_ValueIsNowDatePlusDaysFromConfiguration(DateTime nowDate, int worksDaysToDeadlineFromNow, DateTime expectedDate)
    //     {
    //         SystemTime.SetDateTime(nowDate);
    //
    //         var deadline = DeadlineTestHelper.CreateDeadline(worksDaysToDeadlineFromNow);
    //
    //         deadline.Date.Should().Be(expectedDate);
    //     }
    // }
}
