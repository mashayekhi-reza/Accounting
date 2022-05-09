using Accounting.Domain.Entities;
using Accounting.Domain.Enums;
using Accounting.Domain.Exceptions;
using Accounting.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Accounting.Domain.Tests
{
    public class TransactionTests
    {
        public static IEnumerable<object[]> ValidTransactionsData =>
            new List<object[]>
            {
                new object[] { 10.00m, TransactionType.Credit, new Cash()},
                new object[] { 20.00m, TransactionType.Debit, new Banking()}
            };

        public static IEnumerable<object[]> InvalidTransactionsData =>
            new List<object[]>
            {
                    new object[] { -10.00m, TransactionType.Credit, new Cash()},
                    new object[] { 0, TransactionType.Debit, new Banking()},
                    new object[] { null, TransactionType.Debit, new Banking()}
            };

        [Theory]
        [MemberData(nameof(ValidTransactionsData))]
        public void CreateValidTransaction(decimal amount, TransactionType transactionType, PaymentMethod paymentMethod)
        {
            var trn = new Transaction(amount, transactionType, paymentMethod);

            Guid.TryParse(trn.ID.ToString(), out _).Should().Be(true);
            trn.Amount.Should().Be(amount);
            trn.Type.Should().Be(transactionType);
            trn.TransactionTime.Date.Should().Be(DateTime.Now.Date);
            trn.PaymentMethod.Type.Should().Be(paymentMethod.Type);
        }

        [Theory]
        [MemberData(nameof(InvalidTransactionsData))]
        public void InvalidAmount(decimal amount, TransactionType transactionType, PaymentMethod paymentMethod)
        {
            Action action = () => new Transaction(amount, transactionType, paymentMethod);

            action.Should().Throw<InvalidTransaction>().WithMessage($"The {nameof(Transaction.Amount)} is out of range!");
        }
    }
}