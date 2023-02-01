namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Dtos;

using System.Text.Json.Serialization;

public sealed class PossibleValueDto
{
    [JsonConstructor]
    public PossibleValueDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }

    internal static PossibleValueDto Map(PossibleValue possibleValue)
    {
        return new PossibleValueDto(possibleValue.Id, possibleValue.Value);
    }
}
