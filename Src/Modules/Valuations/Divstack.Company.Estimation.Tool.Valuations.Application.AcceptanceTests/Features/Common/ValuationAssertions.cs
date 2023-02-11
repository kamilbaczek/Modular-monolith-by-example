namespace Divstack.Company.Estimation.Tool.Valuations.Application.AcceptanceTests.Features.Common;

using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

internal static class ValuationAssertions
{
    private const string Approved = "Approved";
    private const string WaitForClientDecision = "WaitForClientDecision";
    private const string WaitForProposal = "WaitForProposal";
    private const string Completed = "Completed";

    internal static AndConstraint<StringAssertions> BeCompleted(this StringAssertions parent)
    {
        return parent.BeWithState(Completed);
    }

    internal static AndConstraint<StringAssertions> BeWaitingForProposal(this StringAssertions parent)
    {
        return parent.BeWithState(WaitForProposal);
    }

    internal static AndConstraint<StringAssertions> BeApproved(this StringAssertions parent)
    {
        return parent.BeWithState(Approved);
    }

    internal static AndConstraint<StringAssertions> BeWaitForClientDecision(this StringAssertions parent)
    {
        return parent.BeWithState(WaitForClientDecision);
    }

    private static AndConstraint<StringAssertions> BeWithState(this StringAssertions parent, string state)
    {
        Execute.Assertion
            .Given(() => parent.Subject)
            .ForCondition(text => text.Equals(state, StringComparison.InvariantCultureIgnoreCase));
        return new AndConstraint<StringAssertions>(parent);
    }
}
