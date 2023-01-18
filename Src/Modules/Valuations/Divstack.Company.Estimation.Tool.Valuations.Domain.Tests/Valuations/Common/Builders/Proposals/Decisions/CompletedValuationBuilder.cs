namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals.Decisions;

using Domain.Valuations;
using Domain.Valuations.States;

internal sealed class CompletedValuationBuilder
{
    private static ValuationApproved ValuationApproved { get; set; }
    
    public CompletedValuationBuilder(ValuationApproved valuationApproved) => 
        ValuationApproved = valuationApproved;

    private static ValuationCompleted WithCompleted()
    {
        var employeeId = new EmployeeId(Guid.NewGuid());
        var completed = ValuationApproved.Complete(employeeId);

        return completed;
    }

    public static implicit operator ValuationCompleted(CompletedValuationBuilder builder)
    {
        var completed = WithCompleted();
        return completed;
    }
}
