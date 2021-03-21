using ValueOf;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Quantity
{
    public class Quantity : ValueOf<long, Quantity>
    {
        public static Quantity operator +(Quantity left, Quantity right) =>
            From(left.Value + right.Value);
    }
}
