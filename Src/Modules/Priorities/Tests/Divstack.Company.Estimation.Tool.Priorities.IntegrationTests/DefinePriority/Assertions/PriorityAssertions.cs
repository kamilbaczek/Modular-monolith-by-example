namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.DefinePriority.Assertions;

using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class PriorityAssertions : 
    ReferenceTypeAssertions<PriorityDto, PriorityAssertions>
{
    public PriorityAssertions(PriorityDto instance)
        : base(instance)
    {
    }

    protected override string Identifier => "priorities";

    public AndConstraint<PriorityAssertions> ShouldBeCorrect(
        ValuationRequested valuationRequested)
    {
        using var scope = new AssertionScope();

        Subject.InquiryId.Should().Be(valuationRequested.InquiryId);
        Subject.ValuationId.Should().Be(valuationRequested.ValuationId);
        Subject.Level.Should().NotBeNull();
        Subject.Archived.Should().BeFalse();
        
        return new AndConstraint<PriorityAssertions>(this);
    }
}
