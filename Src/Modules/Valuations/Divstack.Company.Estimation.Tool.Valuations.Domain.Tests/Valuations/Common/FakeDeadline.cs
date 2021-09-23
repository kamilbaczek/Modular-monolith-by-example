using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;
using Moq;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common
{
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
}