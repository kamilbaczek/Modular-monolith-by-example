namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Priorities;

public sealed record PriorityLevel(string Name, int Weight , int? Scores)
{
    private const int HighLevelScoreBoundary = 20;
    private const int MediumLevelScoreBoundary = 10;

    private static PriorityLevel Low(int scores) => Create(nameof(Low), 0, scores);
    private static PriorityLevel Medium(int scores) => Create(nameof(Medium), 1, scores);
    private static PriorityLevel High(int scores) => Create(nameof(High),2, scores);

    private static PriorityLevel Create(string value, int weight, int scores)
    {
        return new PriorityLevel(value, weight, scores);
    }

    internal static PriorityLevel Calculate(IReadOnlyCollection<ClientLoseRisk> scores)
    {
        var sumScores = scores.Sum(priorityScores => priorityScores.Scores);
        return sumScores switch
        {
            >= HighLevelScoreBoundary => High(sumScores),
            >= MediumLevelScoreBoundary => Medium(sumScores),
            _ => Low(sumScores)
        };
    }

    public static bool operator >(PriorityLevel S1, PriorityLevel S2)
    {
        return S1.Weight > S2.Weight;
    }

    public static bool operator <(PriorityLevel S1, PriorityLevel S2)
    {
        return S1.Weight < S2.Weight;
    }

}
