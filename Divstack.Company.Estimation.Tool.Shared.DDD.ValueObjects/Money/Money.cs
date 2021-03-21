using ValueOf;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Money
{
    public class Money : ValueOf<(decimal Amount, string Currency), Money>
    {
        protected override void Validate()
        {
            if (Value.Amount < 0)
                throw new AmountCannotBeNegative();
            if (string.IsNullOrEmpty(Value.Currency))
            {
                throw new InvalidCurrencyException(Value.Currency);
            }
            base.Validate();
        }
    }
}
