using Accounting.Domain.Enums;

namespace Accounting.Domain.ValueObjects
{
    public class Cash : PaymentMethod
    {
        public Cash()
        {
            Type = PaymentType.Cash;
        }
    }
}