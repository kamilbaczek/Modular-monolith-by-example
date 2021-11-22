namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders;

internal static class A
{
    internal static ValuationBuilder Valuation()
    {
        return new ValuationBuilder();
    }

    internal static DeadlineBuilder Deadline()
    {
        return new DeadlineBuilder();
    }
}
