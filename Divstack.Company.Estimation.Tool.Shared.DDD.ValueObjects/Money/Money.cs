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

    public class Address : ValueOf<(string Address, string State, string PostCode), Address>
    {

    }

    public class Test
    {
        public Test()
        {
            var orderAddress = Address.From(("test", "Test", "Test"));
            var userAddress = Address.From(("test", "Test", "Test"));
            if(orderAddress == userAddress)
            {}

        }
    }
}
