namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests.Common.Assertions.Priorities.Levels;

using FluentAssertions.Primitives;

internal sealed class PriorityLevelAssertions : ReferenceTypeAssertions<PriorityLevel, PriorityLevelAssertions>
{
    public PriorityLevelAssertions(PriorityLevel instance)
        : base(instance)
    {
    }

    protected override string Identifier => "PriorityLevel";

    public AndConstraint<PriorityLevelAssertions> BePriorityLevel(
        string name, int? scores, int weight)
    {
        this.Subject.Name.Should().Be(name);
        this.Subject.Scores.Should().Be(scores);
        this.Subject.Weight.Should().Be(weight);

        return new AndConstraint<PriorityLevelAssertions>(this);
    }
}
