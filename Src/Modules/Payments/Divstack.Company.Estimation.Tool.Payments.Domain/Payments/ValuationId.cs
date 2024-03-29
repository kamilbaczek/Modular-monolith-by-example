﻿namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public record ValuationId(Guid Value)
{
    public static ValuationId Of(Guid id) => new(id);
}
