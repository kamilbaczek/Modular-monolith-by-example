namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

using System;

public record EmployeeId(Guid Value)
{
    public static EmployeeId Of(Guid guid)
    {
        return new EmployeeId(guid);
    }
}
