using Accounting.Domain.Entities;
using Accounting.Domain.Enums;
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
    }
}