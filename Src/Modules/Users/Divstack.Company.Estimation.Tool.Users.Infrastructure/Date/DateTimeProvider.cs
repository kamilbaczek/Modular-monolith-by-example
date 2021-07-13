using System;
using Divstack.Company.Estimation.Tool.Users.Domain;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Date
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        private const string DateFormatConfigurationName = "DateFormat";

        public DateTimeProvider(IConfiguration configuration)
        {
            DateFormat = configuration[DateFormatConfigurationName];
        }

        private string DateFormat { get; }
        public DateTime NowDate => DateTime.Now.Date;
        public string NowDateFormatted => NowDate.ToString(DateFormat);
        public DateTime Now => DateTime.Now;
    }
}