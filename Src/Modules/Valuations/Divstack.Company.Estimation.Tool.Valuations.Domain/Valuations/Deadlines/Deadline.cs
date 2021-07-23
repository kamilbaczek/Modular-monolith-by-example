using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines
{
    public sealed class Deadline : ValueObject
    {
        private Deadline()
        {
        }

        private Deadline(int daysToDeadlineFromNow)
        {
            Date = SystemTime.Now().AddDays(daysToDeadlineFromNow);
        }

        public static Deadline Create(IDeadlinesConfiguration deadlinesConfiguration)
        {
            return new(deadlinesConfiguration.WorksDaysToDeadlineFromNow);
        }

        internal DateTime Date { get; }
    }
}
