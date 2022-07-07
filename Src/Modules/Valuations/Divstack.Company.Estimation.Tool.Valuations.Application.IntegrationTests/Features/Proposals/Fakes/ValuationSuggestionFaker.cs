namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Proposals.Fakes;

using System;
using Faker;
using Valuations.Commands.SuggestProposal;

internal static class ValuationSuggestionFaker
{
    internal static SuggestProposalCommand Create(Guid valuationId)
    {
        return new SuggestProposalCommand
        {
            Currency = Currency.ThreeLetterCode(),
            Description = Lorem.Sentence(),
            ValuationId = valuationId,
            Value = 333m
        };
    }
}
