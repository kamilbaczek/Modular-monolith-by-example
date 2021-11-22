namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders;

using Domain.Valuations.Deadlines;
using Moq;

internal sealed class DeadlineBuilder
{
    private const int FakeWorksDaysToDeadlineFromNow = 10;
    private readonly Mock<IDeadlinesConfiguration> _configurationMock = new();

    public DeadlineBuilder()
    {
        _configurationMock
            .Setup(deadlinesConfiguration => deadlinesConfiguration.WorksDaysToDeadlineFromNow)
            .Returns(FakeWorksDaysToDeadlineFromNow);
    }

    internal DeadlineBuilder WithDeadline(int worksDaysToDeadlineFromNow)
    {
        _configurationMock
            .Setup(deadlinesConfiguration => deadlinesConfiguration.WorksDaysToDeadlineFromNow)
            .Returns(worksDaysToDeadlineFromNow);
        return this;
    }

    private Deadline Build()
    {
        return Deadline.Create(_configurationMock.Object);
    }

    public static implicit operator Deadline(DeadlineBuilder builder)
    {
        return builder.Build();
    }
}
