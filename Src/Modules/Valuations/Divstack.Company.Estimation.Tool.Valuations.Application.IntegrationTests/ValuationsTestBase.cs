namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests;

using System.Threading.Tasks;
using NUnit.Framework;

public abstract class ValuationsTestBase
{
    [SetUp]
    public Task TestSetUp()
    {
        return Task.CompletedTask;
    }

    [TearDown]
    public Task Cleanup()
    {
        return Task.CompletedTask;
    }
}
