using System;

namespace Divstack.Company.Estimation.Tool.Users.Domain
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime NowDate { get; }
        public string NowDateFormatted { get; }
    }
}