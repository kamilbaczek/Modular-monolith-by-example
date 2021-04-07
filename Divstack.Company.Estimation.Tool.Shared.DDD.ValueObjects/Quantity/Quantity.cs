using System;
using ValueOf;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Quantity
{
    public class Quantity : ValueOf<long, Quantity>
    {
        protected override void Validate()
        {
            if (Value < 0)
                throw new QuantityCannotBeNegative();
            base.Validate();
        }

        public static Quantity operator +(Quantity left, Quantity right) =>
            From(left.Value + right.Value);
    }

}
