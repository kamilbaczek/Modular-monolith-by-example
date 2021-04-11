using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects
{
    public class Money : ValueObject
    {
        private Money()
        {
        }

        public static Money Undefined => new Money(null, null);

        public decimal? Value { get; }

        public string Currency { get; }

        public static Money Of(decimal value, string currency)
        {
            return new Money(value, currency);
        }

        private Money(decimal? value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public static Money operator *(int left, Money right)
        {
            return new Money(right.Value * left, right.Currency);
        }
    }
}
