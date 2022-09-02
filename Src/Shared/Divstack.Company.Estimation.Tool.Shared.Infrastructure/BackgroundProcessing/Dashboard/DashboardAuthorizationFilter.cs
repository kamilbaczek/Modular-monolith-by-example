namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing.Dashboard;

using Hangfire.Dashboard;
using Microsoft.Extensions.Hosting;

internal sealed class DashboardAuthorizationFilter : IDashboardAuthorizationFilter, IDashboardAsyncAuthorizationFilter
{
    private readonly IHostEnvironment _hostEnvironment;
    public DashboardAuthorizationFilter(IHostEnvironment hostEnvironment) => _hostEnvironment = hostEnvironment;

    public bool Authorize(DashboardContext dashboardContext) => true;
    public Task<bool> AuthorizeAsync(DashboardContext context)
    {
        var authorized = !_hostEnvironment.IsProduction();

        return Task.FromResult(authorized);
    }
}
