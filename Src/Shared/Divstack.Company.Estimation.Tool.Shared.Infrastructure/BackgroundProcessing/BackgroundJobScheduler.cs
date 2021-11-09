using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Hangfire;
using Hangfire.Common;
using Hangfire.Storage.Monitoring;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing
{
    internal sealed class BackgroundJobScheduler : IBackgroundJobScheduler
    {
        private const int Zero = 0;

        public void Schedule(Expression<Action> methodCall, DateTime date)
        {
            var enqueueAt = new DateTimeOffset(date);
            BackgroundJob.Schedule(
                methodCall,
                enqueueAt);
        }

        public void UnSchedule(Expression<Action> methodCall)
        {
            var methodAsJob = Job.FromExpression(methodCall);
            var monitor = JobStorage.Current.GetMonitoringApi();
            var jobsToUnSchedule = monitor
                .ScheduledJobs(Zero, int.MaxValue)
                .Where(jobKeyValues => JobEquals(jobKeyValues.Value.Job, methodAsJob));

            UnSchedule(jobsToUnSchedule);
        }

        private static void UnSchedule(IEnumerable<KeyValuePair<string, ScheduledJobDto>> scheduledJobsWithMethod)
        {
            foreach (var scheduledJob in scheduledJobsWithMethod) BackgroundJob.Delete(scheduledJob.Key);
        }

        private static bool JobEquals(Job right, Job left)
        {
            var namesEquals = right.Method == left.Method;
            var areArgsEquals = AreArgsEquals(right, left);

            return namesEquals && areArgsEquals;
        }

        private static bool AreArgsEquals(Job right, Job left)
        {
            var areArgsEquals = true;
            for (var index = 0; index < right.Args.Count; index++)
            {
                var rightArg = right.Args[index];
                var leftArg = left.Args[index];
                if (!rightArg.Equals(leftArg))
                    areArgsEquals = false;
            }

            return areArgsEquals;
        }
    }
}