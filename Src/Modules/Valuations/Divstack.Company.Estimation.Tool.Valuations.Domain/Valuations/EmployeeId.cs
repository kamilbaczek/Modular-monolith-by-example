namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

public record struct EmployeeId(Guid Value)
{
    public static EmployeeId Of(Guid guid) => new(guid);
}
