using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Events
{
    public sealed class ValuationCompletedEvent : DomainEventBase
    {
        public ValuationCompletedEvent(EmployeeId closedBy, ValuationId valuationId)
        {
            ClosedBy = closedBy;
            ValuationId = valuationId;
        }

        public EmployeeId ClosedBy { get;  }
        public ValuationId  ValuationId { get;  }

    }
}
