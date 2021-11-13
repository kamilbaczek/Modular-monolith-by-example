namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes;

using System;
using Faker;
using Valuations.Commands.SuggestProposal;

internal static class FakeValuationSuggestion
{
    internal static SuggestProposalCommand GenerateFakeSuggestProposalCommand(Guid valuationId)
    {
        return new SuggestProposalCommand
        {
            Currency = Currency.ThreeLetterCode(), Description = Lorem.Sentence(), ValuationId = valuationId, Value = 333m
        };
    }
}
