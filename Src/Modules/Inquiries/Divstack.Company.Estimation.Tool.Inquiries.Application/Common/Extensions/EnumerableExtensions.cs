namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Extensions;

internal static class EnumerableExtensions
{
    public static IReadOnlyCollection<T> ToReadonly<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.ToList().AsReadOnly();
    }
}
