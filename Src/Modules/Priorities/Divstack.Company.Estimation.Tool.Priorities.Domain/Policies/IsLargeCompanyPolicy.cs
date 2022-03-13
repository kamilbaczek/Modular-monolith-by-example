namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Policies;

internal sealed class IsLargeCompanyPolicy
{
    private const int LargeCompanySize = 100;
    public bool IsLargeCompany(int? companySize) => LargeCompanySize <= companySize;
}
