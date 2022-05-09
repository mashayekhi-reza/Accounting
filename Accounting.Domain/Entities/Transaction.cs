using Accounting.Domain.Enums;
using Accounting.Domain.Exceptions;
using System;

namespace Accounting.Domain.Entities
{
    public class Transaction : Entity
    {
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime TransactionTime { get; private set; }
        public PaymentType PaymentType { get; private set; }

        public Transaction(decimal amount, TransactionType type, PaymentType paymentType)
        {
            if(amount <= 0)
                throw new InvalidTransaction($"The {nameof(Amount)} is out of range!");

            Amount = amount;
            Type = type;
            TransactionTime = DateTime.Now;
            PaymentType = paymentType;
        }
    }
}
