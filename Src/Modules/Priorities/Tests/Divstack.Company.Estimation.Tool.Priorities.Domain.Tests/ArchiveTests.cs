namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests;

using Common.Builders;
using Events;

public class ArchiveTests : BasePriorityTest
{
    [Test]
    public void Given_Archive_Then_Archived()
    {
        Priority priority = A.Priority();

        priority.Archive();

        var @event = GetPublishedEvent<PriorityArchivedDomainEvent>(priority);
        @event.Should().NotBeNull();
    }
}
