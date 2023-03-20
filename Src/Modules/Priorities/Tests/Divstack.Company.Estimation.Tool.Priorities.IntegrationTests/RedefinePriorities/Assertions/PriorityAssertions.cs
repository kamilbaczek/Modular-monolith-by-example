namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.RedefinePriorities.Assertions;

using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;
using Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class PriorityAssertions : ReferenceTypeAssertions<PrioritiesListVm, PriorityAssertions>
{
    private const string Medium = "Medium";
    private const string Low = "Low";
    
    public PriorityAssertions(PrioritiesListVm prioritiesResult) : base(prioritiesResult)
    {
    }

    protected override string Identifier => "priorities";
    

    internal AndConstraint<PriorityAssertions> HavePrioritiesInMediumLevel(IEnumerable<ValuationRequested> valuationRequests) => 
        HavePrioritiesInLevel(Medium, valuationRequests);

    internal AndConstraint<PriorityAssertions> HavePrioritiesInLowLevel(IEnumerable<ValuationRequested> valuationRequests) => 
        HavePrioritiesInLevel(Low, valuationRequests);

    private AndConstraint<PriorityAssertions> HavePrioritiesInLevel(string level, IEnumerable<ValuationRequested> valuationRequests)
    {
        var valuationsIds = valuationRequests.Select(valuationRequested => valuationRequested.ValuationId).ToList();
        var priorities = Subject.Priorities.Where(priority => valuationsIds.Contains(priority.ValuationId)).ToList();
        using (new AssertionScope())
        {
            foreach (var priority in priorities) 
                priority.Level.Should().Be(level);
        }

        return new AndConstraint<PriorityAssertions>(this);
    }
}
