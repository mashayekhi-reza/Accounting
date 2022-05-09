using Accounting.Domain.Enums;
using Accounting.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Accounting.Domain.Entities
{
    public class Transaction : Entity
    {
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime Time { get; private set; }
        public Account Account { get; private set; }
        public List<Tag> Tags { get; private set; }

        public Transaction(decimal amount, TransactionType type, Account account)
        {
            // TODO: add tests
            if (amount <= 0)
                throw new InvalidTransaction($"The {nameof(Amount)} is out of range!");

            Amount = amount;
            Type = type;
            Time = DateTime.Now;
            Account = account;
            Tags = new List<Tag>();          
        }

        public void AddTag(Tag tag)
        {
            // TODO: check if it is not in the list
            Tags.Add(tag);
        }

        public void RemoveTag(Tag tag)
        {
            // TODO: check if it is in the list
            Tags.Remove(tag);
        }
    }
}
