using Accounting.Common;
using Accounting.Domain.Entities;
using Accounting.Domain.Entities.Transaction;
using Accounting.Domain.Enums;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Accounting.Domain.Tests.Entities;

public class TransactionTest
{
    public static IEnumerable<object[]> ValidTransactionsData =>
        new List<object[]>
        {
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), 10.00m, TransactionType.Credit,
            new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Cash",
                new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())) },
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), 10.00m, TransactionType.Debit,
            new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "My Bank",
                new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())) }
        };

    [Theory]
    [MemberData(nameof(ValidTransactionsData))]
    public void CreateTransactionSuccessfully(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy,
        decimal amount, TransactionType type, Account account)
    {
        var trn = new Transaction(id, createdOn, createdBy, modifiedOn, modifiedBy,
        amount, type, account);

        trn.ID.Should().Be(id);
        trn.CreatedOn.Should().Be(createdOn);
        trn.CreatedBy.Should().Be(createdBy);
        trn.ModifiedOn.Should().Be(modifiedOn);
        trn.ModifiedBy.Should().Be(modifiedBy);
        trn.Amount.Should().Be(amount);
        trn.Type.Should().Be(type);
        trn.Account.Should().Be(account);
        trn.Amount.Should().Be(amount);
    }

    [Fact]
    public void ThrowExceptionWhenTransactionAmountIsNegative()
    {
        Action action = () => new Transaction(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), -10.00m, TransactionType.Credit,
            new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Cash", 
            new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())));


        action.Should().Throw<ValidationException>()
            .Where(e => e.ErrorCode == ErrorCode.InvalidTransactionOperation)
            .WithMessage($"The {nameof(Transaction.Amount)} is out of range!");
    }

    [Fact]
    public void AddTagSuccessfully()
    {
        var trn = CreateAValidTransaction();
        var tag = new Tag(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Grocery");

        trn.AddTag(tag);

        trn.Tags.Count.Should().Be(1);
        trn.Tags.FirstOrDefault().Should().Be(tag);
    }

    [Fact]
    public void AddSeveralTagsToTheTransactionSuccessfully()
    {
        Transaction trn = CreateAValidTransaction();
        var tags = new List<Tag>
        {
            new Tag(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Grocery"),
            new Tag(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Food"),
            new Tag(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Fun"),
            new Tag(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Educational")
        };
        tags.ForEach(t => trn.AddTag(t));

        trn.Tags.Count.Should().Be(4);
        for (var i = 0; i < tags.Count; i++)
            trn.Tags[i].Should().Be(tags[i]);
    }

    [Fact]
    public void ThrowExceptionWhenATagIsAvailableInTransactionTagListedAndItIsRequestedToBeAdded()
    {
        Transaction trn = CreateAValidTransaction();
        var tag = new Tag(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Grocery");
        trn.AddTag(tag);

        Action action = () => trn.AddTag(tag);
        action.Should().Throw<ValidationException>()
            .Where(e => e.ErrorCode == ErrorCode.InvalidTagOperation)
            .WithMessage($"The {nameof(Tag)} has already been added!");
    }

    [Fact]
    public void ThrowExceptionWhenRemoveTagRequestedAndTagIsNotInTheTransactionList()
    {
        Transaction trn = CreateAValidTransaction();
        var tag = new Tag(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Grocery");

        Action action = () => trn.RemoveTag(tag);
        action.Should().Throw<ValidationException>()
            .Where(e => e.ErrorCode == ErrorCode.InvalidTagOperation)
            .WithMessage($"The {nameof(Tag)} has not found!");
    }

    private static Transaction CreateAValidTransaction()
    {
        return new Transaction(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), 10.00m, TransactionType.Credit,
                        new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Cash", 
                        new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())));
    }
}