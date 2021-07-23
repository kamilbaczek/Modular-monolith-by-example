﻿using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events
{
    public sealed class ValuationDeadlineFixedEvent : DomainEventBase
    {
        public ValuationDeadlineFixedEvent(ValuationId valuationId, Deadline deadline)
        {
            ValuationId = valuationId;
            Date = deadline.Date;
        }

        public ValuationId ValuationId { get; }
        public DateTime Date { get; }

    }
}
