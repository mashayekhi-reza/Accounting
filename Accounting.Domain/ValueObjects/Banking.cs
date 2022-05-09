using Accounting.Domain.Enums;

namespace Accounting.Domain.ValueObjects
{
    public class Banking : PaymentMethod
    {
        public Banking()
        {
            Type = PaymentType.Online;
        }

        public TransferType TransferType { get; private set; }
    }
}