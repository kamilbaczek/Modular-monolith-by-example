namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Priorities.Policies;

internal sealed class IsLargeCompanyPolicy
{
    private const int LargeCompanySize = 100;
    public bool IsLargeCompany(int? companySize) => companySize < LargeCompanySize;
}
