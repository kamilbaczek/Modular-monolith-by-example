namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests;

using System.Threading.Tasks;
using NUnit.Framework;
using static ValuationsTesting;

public abstract class ValuationsTestBase
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }

    [TearDown]
    public async Task Cleanup()
    {
        await ResetState();
    }
}
