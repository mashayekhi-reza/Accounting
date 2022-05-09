using Accounting.Domain.Entities;
using Accounting.Domain.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace Accounting.Domain.Tests
{
    public class TransactionTests
    {
        [Fact]
        public void CreateCashTransaction()
        {
            var transaction = new Transaction(10.00m, Enums.TransactionType.Credit, new Cash());

            bool isValid = Guid.TryParse(transaction.ID.ToString(), out _);
            isValid.Should().Be(true);
            transaction.Amount.Should().Be(10.00m);
            transaction.TransactionTime.Date.Should().Be(DateTime.Now.Date);
            transaction.PaymentMethod.GetType().Should().Be(typeof(Cash));
        }
    }
}