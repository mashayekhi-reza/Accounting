using Accounting.Application.DTOs;
using Accounting.Application.Transactions.Commands;
using Accounting.Domain.Enums;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Accounting.Application.Tests.Transactions.Commands;

public class CreateTransactionCommandValidatorTest
{

    private readonly CreateTransactionCommandValidator _validator = new CreateTransactionCommandValidator();

    public static IEnumerable<object[]> ValidCreateTransactionCommandData =>
    new List<object[]>
    {
        new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), 10.00m, TransactionType.Credit,
        new AccountDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Cash",
            new TenantDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())) },
        new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), 10.00m, TransactionType.Debit,
        new AccountDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "My Bank",
            new TenantDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())) }
    };

    public static IEnumerable<object[]> NegativeAmounts =>
    new List<object[]>
    {
        new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), -220, TransactionType.Credit,
        new AccountDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Cash",
            new TenantDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())) },
        new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), -10.00m, TransactionType.Debit,
        new AccountDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "My Bank",
            new TenantDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())) }
    };

    [Theory]
    [MemberData(nameof(ValidCreateTransactionCommandData))]
    public void CreateTransactionCommandsAreValidSoThatTheValidatorShouldReturnIsValid(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy,
            decimal amount, TransactionType type, AccountDto account)
    {
        var request = new CreateTransactionCommand(
            new TransactionDto(id, createdOn, createdBy, modifiedOn, modifiedBy,
            amount, type, account));

        _validator.Validate(request).IsValid.Should().Be(true);
    }


    [Theory]
    [MemberData(nameof(NegativeAmounts))]
    public void ValidationFailedForNegativeTransactionAmounts(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy,
            decimal amount, TransactionType type, AccountDto account)
    {
        var request = new CreateTransactionCommand(
            new TransactionDto(id, createdOn, createdBy, modifiedOn, modifiedBy,
            amount, type, account));

        var result = _validator.Validate(request);
        result.IsValid.Should().Be(false);
        result.Errors.First().ErrorMessage.Should().Contain("must be greater than '0'");
    }

    [Fact]
    public void ValidationFailedForNullTransactionAccountName()
    {
        var request = new CreateTransactionCommand(
            new TransactionDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), 10.00m, TransactionType.Credit,
                new AccountDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "",
                new TenantDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid()))));

        var result = _validator.Validate(request);
        result.IsValid.Should().Be(false);
        result.Errors.First().ErrorMessage.Should().Contain("must be between 1 and 100 characters.");
    }
}
