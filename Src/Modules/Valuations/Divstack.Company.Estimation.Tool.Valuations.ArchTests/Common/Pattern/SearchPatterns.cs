namespace Divstack.Company.Estimation.Tool.Valuations.ArchTests.Common.Pattern;

internal static class SearchPatterns
{
    internal static string ContainsNamePattern(string name) => 
        $"(?i){name}";
}
