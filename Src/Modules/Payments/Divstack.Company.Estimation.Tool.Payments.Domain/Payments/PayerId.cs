using System;

namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments
{
    public record PaymentId(Guid Value)
    {
        public static PaymentId Create()
        {
            return new PaymentId(Guid.NewGuid());
        }
        
        public static PaymentId Of(Guid id)
        {
            return new PaymentId(id);
        }
    }
}