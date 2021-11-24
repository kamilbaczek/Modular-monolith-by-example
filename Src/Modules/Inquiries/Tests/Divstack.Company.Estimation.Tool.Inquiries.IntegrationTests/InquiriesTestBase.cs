namespace Divstack.Company.Estimation.Tool.Inquiries.IntegrationTests;

using System.Threading.Tasks;
using NUnit.Framework;
using static InquiriesTesting;

public abstract class InquiriesTestBase
{
    [TearDown]
    public async Task Cleanup()
    {
        await ResetState();
    }
}
