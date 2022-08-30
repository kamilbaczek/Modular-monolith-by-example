namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests;

using Common.Builders;
using Events;

public class ForceTests : BasePriorityTest
{
    private const string Name = "Test";

    [Test]
    public void Given_Force_Then_CalculatedPriorityIsIgnored()
    {
        Priority priority = A.Priority().WithCompanySize(10);
        var level = new PriorityLevel(Name, 1, 1);

        priority.Force(level);

        var @event = GetPublishedEvent<PriorityForcedDomainEvent>(priority);
        @event.Should().NotBeNull();
    }
}
