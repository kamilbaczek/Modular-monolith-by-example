namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common.Fakes;

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
