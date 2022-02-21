namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public sealed record ClientLoseRisk(string Name, int Scores)
{
    private const int DeadlineExceedScore = 15;
    private const int LargeClientCompanyScore = 5;
    private const int CloseToDeadlineNoRiskScore = 10;

    internal static ClientLoseRisk DeadlineExceed => Create(nameof(DeadlineExceedScore),DeadlineExceedScore);
    internal static ClientLoseRisk CloseToDeadline(int days) => CreateCloseToDeadline(nameof(CloseToDeadlineNoRiskScore), days);
    internal static ClientLoseRisk LargeClientCompany => Create(nameof(LargeClientCompany),LargeClientCompanyScore);

    private static ClientLoseRisk Create(string name, int value)
    {
        return new ClientLoseRisk(name, value);
    }

    private static ClientLoseRisk CreateCloseToDeadline(string name, int days)
    {
        var scores = CloseToDeadlineNoRiskScore - days;
        return new ClientLoseRisk(name, scores);
    }
}
