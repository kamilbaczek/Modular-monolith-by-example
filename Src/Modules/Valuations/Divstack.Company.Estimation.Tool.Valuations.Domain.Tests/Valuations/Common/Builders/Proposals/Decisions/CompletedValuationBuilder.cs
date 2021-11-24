namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals.Decisions;

using Domain.Valuations;

internal sealed class CompletedValuationBuilder
{
    public CompletedValuationBuilder(Valuation valuation)
    {
        Valuation = valuation;
    }
    private static Valuation Valuation { get; set; }

    private static Valuation WithCompleted()
    {
        var employeeId = new EmployeeId(Guid.NewGuid());
        Valuation.Complete(employeeId);

        return Valuation;
    }

    public static implicit operator Valuation(CompletedValuationBuilder builder)
    {
        return WithCompleted();
    }
}
