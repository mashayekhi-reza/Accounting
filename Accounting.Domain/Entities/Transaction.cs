﻿using Accounting.Domain.Enums;
using Accounting.Domain.Exceptions;
using System;

namespace Accounting.Domain.Entities
{
    public class Transaction : Entity
    {
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime Time { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public Transaction(decimal amount, TransactionType type, PaymentMethod paymentType)
        {
            if(amount <= 0)
                throw new InvalidTransaction($"The {nameof(Amount)} is out of range!");

            Amount = amount;
            Type = type;
            Time = DateTime.Now;
            PaymentMethod = paymentType;
        }
    }
}
