using Accounting.Domain.Enums;
using Accounting.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Accounting.Domain.Entities.Transaction
{
    public class Transaction : Entity
    {
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public Account Account { get; private set; }
        public List<Tag> Tags { get; private set; }

        public Transaction(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy, decimal amount, TransactionType type, Account account)
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy)
        {
            if (amount <= 0)
                throw new InvalidTransaction($"The {nameof(Amount)} is out of range!");

            Amount = amount;
            Type = type;
            Account = account;
            Tags = new List<Tag>();
        }

        public void AddTag(Tag tag)
        {
            if (Tags.Contains(tag))
                throw new InvalidTagOperation($"The {nameof(Tag)} has already been added!");

            Tags.Add(tag);
        }

        public void RemoveTag(Tag tag)
        {
            if (!Tags.Contains(tag))
                throw new InvalidTagOperation($"The {nameof(Tag)} has not found!");

            Tags.Remove(tag);
        }
    }
}
