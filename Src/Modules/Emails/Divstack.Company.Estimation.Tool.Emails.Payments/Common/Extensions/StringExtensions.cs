namespace Divstack.Company.Estimation.Tool.Emails.Payments.Common.Extensions;

internal static class StringExtensions
{
    internal static string ReplaceIgnoreCases(this string text, string old, string @new)
    {
        return text.Replace(old, @new, StringComparison.CurrentCultureIgnoreCase);
    }

    internal static string ReplaceIgnoreCases(this string text, string old, Guid @new)
    {
        return text.Replace(old, @new.ToString(), StringComparison.CurrentCultureIgnoreCase);
    }
}
