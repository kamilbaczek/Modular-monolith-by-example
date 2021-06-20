using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes
{
    internal static class FakeValuationSuggestion
    {
        internal static SuggestProposalCommand GenerateFakeSuggestProposalCommand(Guid valuationId) => new()
        {
            Currency = Faker.Currency.ThreeLetterCode(),
            Description = Faker.Lorem.Sentence(),
            ValuationId = valuationId,
            Value = 333m
        };
    }
}
