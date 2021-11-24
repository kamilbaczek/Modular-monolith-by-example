namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Quantity;

using ValueOf;

public class Quantity : ValueOf<long, Quantity>
{
    protected override void Validate()
    {
        if (Value < 0)
        {
            throw new QuantityCannotBeNegative();
        }

        base.Validate();
    }

    public static Quantity operator +(Quantity left, Quantity right)
    {
        return From(left.Value + right.Value);
    }
}
