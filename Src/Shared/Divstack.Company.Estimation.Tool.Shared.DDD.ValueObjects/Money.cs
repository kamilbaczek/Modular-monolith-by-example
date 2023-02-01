#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

using BuildingBlocks;

public class Money : ValueObject
{
    private const string DefaultCurrency = "USD";
    
    private Money()
    {
    }
    
    private Money(decimal? value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    public static Money Undefined => new(null, DefaultCurrency);

    public decimal? Value { get; init; }

    public string Currency { get; init; }

    public static Money Of(decimal? value, string currency)
    {
        return new Money(value, currency);
    }

    public static Money operator *(int left, Money right)
    {
        return new Money(right.Value * left, right.Currency);
    }

    public static bool operator <(Money left, Money right)
    {
        return left.Value < right.Value;
    }

    public static bool operator >(Money left, Money right)
    {
        return left.Value > right.Value;
    }
}
