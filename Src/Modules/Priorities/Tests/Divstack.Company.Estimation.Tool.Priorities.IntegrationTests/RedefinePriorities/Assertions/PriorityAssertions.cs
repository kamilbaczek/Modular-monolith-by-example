namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.RedefinePriorities.Assertions;

using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

internal sealed class PriorityAssertions : ReferenceTypeAssertions<PrioritiesListVm, PriorityAssertions>
{
    private const string Medium = "Medium";
    private const string Low = "Low";
    
    public PriorityAssertions(PrioritiesListVm prioritiesResult) : base(prioritiesResult)
    {
    }

    protected override string Identifier => "priorities";
    

    internal AndConstraint<PriorityAssertions> HavePrioritiesInMediumLevel() => 
        HavePrioritiesInLevel(Medium);

    internal AndConstraint<PriorityAssertions> HavePrioritiesInLowLevel() => 
        HavePrioritiesInLevel(Low);

    private AndConstraint<PriorityAssertions> HavePrioritiesInLevel(string level)
    {
        using (new AssertionScope())
        {
            foreach (var priority in Subject.Priorities) 
                priority.Level.Should().Be(level);
        }

        return new AndConstraint<PriorityAssertions>(this);
    }
}
