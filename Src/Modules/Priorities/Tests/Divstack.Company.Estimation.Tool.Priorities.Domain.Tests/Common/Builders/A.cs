namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests.Common.Builders;

internal static class A
{
    internal static DeadlineBuilder Deadline()
    {
        return new DeadlineBuilder();
    }

    internal static PrioritiesBuilder Priority()
    {
        return new PrioritiesBuilder();
    }
}
