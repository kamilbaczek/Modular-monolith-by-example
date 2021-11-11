using System;

namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Payers;

public record PayerId(Guid Value)
{
    public static PayerId Of(Guid id)
    {
        return new PayerId(id);
    }
}
