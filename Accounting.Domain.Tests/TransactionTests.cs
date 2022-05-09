using Accounting.Domain.Entities;
using Accounting.Domain.Enums;
using Accounting.Domain.Exceptions;
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
                new object[] { 10.00m, TransactionType.Credit, PaymentMethod.Cash},
                new object[] { 20.00m, TransactionType.Debit, PaymentMethod.BankTransfer},
                new object[] { 30.00m, TransactionType.Credit, PaymentMethod.CreditCard},
                new object[] { 40.00m, TransactionType.Debit, PaymentMethod.DebitCard},
                new object[] { 50.00m, TransactionType.Credit, PaymentMethod.Cryptocurrency}
            };

        public static IEnumerable<object[]> InvalidTransactionAmountData =>
            new List<object[]>
            {
                    new object[] { -10.00m, TransactionType.Credit, PaymentMethod.Cash},
                    new object[] { 0, TransactionType.Debit, PaymentMethod.BankTransfer},
                    new object[] { null, TransactionType.Debit, PaymentMethod.BankTransfer}
            };

        [Theory]
        [MemberData(nameof(ValidTransactionsData))]
        public void CreateValidTransaction(decimal amount, TransactionType transactionType, PaymentMethod paymentType)
        {
            var trn = new Transaction(amount, transactionType, paymentType);

            Guid.TryParse(trn.ID.ToString(), out _).Should().Be(true);
            trn.Amount.Should().Be(amount);
            trn.Type.Should().Be(transactionType);
            trn.Time.Date.Should().Be(DateTime.Now.Date);
            trn.PaymentMethod.Should().Be(paymentType);
        }

        [Theory]
        [MemberData(nameof(InvalidTransactionAmountData))]
        public void InvalidAmount(decimal amount, TransactionType transactionType, PaymentMethod paymentType)
        {
            Action action = () => new Transaction(amount, transactionType, paymentType);

            action.Should().Throw<InvalidTransaction>().WithMessage($"The {nameof(Transaction.Amount)} is out of range!");
        }
    }
}