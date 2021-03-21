using System;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Money
{
    public class AmountCannotBeNegative : Exception
    {
        public AmountCannotBeNegative() : base("Amount cannot be negative")
        {
        }
    }
}
