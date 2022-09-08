namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Common.Enviroments;

internal record struct Enviroment(string Name)
{
    public static Enviroment Staging => new("Stage");

    public override string ToString() => Name.ToLower();
    public static implicit operator string(Enviroment enviroment) => enviroment.ToString();
}
