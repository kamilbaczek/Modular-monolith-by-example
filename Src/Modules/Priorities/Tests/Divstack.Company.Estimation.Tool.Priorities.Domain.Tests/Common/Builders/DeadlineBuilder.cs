namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests.Common.Builders;

using Deadlines;
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

    private Deadline Build() => 
        Deadline.Create(_configurationMock.Object);

    public static implicit operator Deadline(DeadlineBuilder builder) => 
        builder.Build();
}
