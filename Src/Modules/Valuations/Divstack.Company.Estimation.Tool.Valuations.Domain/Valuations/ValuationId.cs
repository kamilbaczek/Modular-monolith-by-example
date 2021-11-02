using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations
{
    public record ValuationId(Guid Value)
    {
        public static ValuationId Create()
        {
            return new ValuationId(Guid.NewGuid());
        }
        
        public static ValuationId Of(Guid guid)
        {
            return new ValuationId(guid);
        }
    };
}