namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests;

using Deadlines;
using Moq;

internal static class FakeDeadline
{
    private const int FakeWorksDaysToDeadlineFromNow = 10;

    internal static Deadline CreateDeadline(int worksDaysToDeadlineFromNow = FakeWorksDaysToDeadlineFromNow)
    {
        var configurationMock = new Mock<IDeadlinesConfiguration>();
        configurationMock
            .Setup(deadlinesConfiguration => deadlinesConfiguration.WorksDaysToDeadlineFromNow)
            .Returns(worksDaysToDeadlineFromNow);

        return Deadline.Create(configurationMock.Object);
    }
}
