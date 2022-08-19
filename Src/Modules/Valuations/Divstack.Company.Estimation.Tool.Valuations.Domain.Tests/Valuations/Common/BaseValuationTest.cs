namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;

using Shared.DDD.BuildingBlocks.Tests;

public abstract class BaseValuationTest : BaseTest
{
    protected const decimal MinimumSuggestionValue = 100;
    protected const string Currency = "USD";
    protected const string Description = "test";

    protected Guid Id => Guid.NewGuid();
}
