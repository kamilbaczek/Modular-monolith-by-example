namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Policies;

internal static class IsLargeCompanyPolicy
{
    private const int LargeCompanySize = 100;
    public static bool IsLargeCompany(int? companySize) => LargeCompanySize <= companySize;
}
