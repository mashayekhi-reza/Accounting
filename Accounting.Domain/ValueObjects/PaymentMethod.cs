using Accounting.Domain.Enums;

namespace Accounting.Domain.ValueObjects
{
    public class PaymentMethod
    {
        public PaymentType Type { get; protected set; }
    }
}