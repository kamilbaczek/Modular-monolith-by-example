namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing.Dashboard;

using Hangfire.Dashboard;

internal sealed class DashboardAuthorizationFilter : IDashboardAuthorizationFilter, IDashboardAsyncAuthorizationFilter
{
    //TODO: implement authorization filter for prod
    public bool Authorize(DashboardContext dashboardContext) => true;
    public Task<bool> AuthorizeAsync(DashboardContext context)
    {
        return Task.FromResult(true);
    }
}
