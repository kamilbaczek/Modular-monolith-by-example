﻿namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

public record struct ValuationId(Guid Value)
{
    public static ValuationId Create() => new(Guid.NewGuid());

    public static ValuationId Of(Guid guid) => new(guid);
}
