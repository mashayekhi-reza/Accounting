using Accounting.Domain.Enums;
using Accounting.Domain.ValueObjects;
using System;

namespace Accounting.Domain.Entities
{
    public class Transaction : Entity
    {
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime TransactionTime { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public Transaction(decimal amount, TransactionType type, PaymentMethod paymentMethod) : base()
        {
            Amount = amount;
            Type = type;
            TransactionTime = DateTime.Now;
            PaymentMethod = paymentMethod;
        }
    }
}
