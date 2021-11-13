namespace Divstack.Company.Estimation.Tool.Users.Domain;

using System;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime NowDate { get; }
    public string NowDateFormatted { get; }
}
