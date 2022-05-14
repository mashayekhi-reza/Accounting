using Accounting.Application.Tests.Mocks;
using Accounting.Application.Transactions.Commands;
using Accounting.Domain.Entities;
using Accounting.Domain.Entities.Transaction;
using Accounting.Domain.Enums;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Accounting.Application.Tests.Transactions.Commands
{
    public class CreateTransactionCommandHandlerTest
    {
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionCommandHandlerTest()
        {
            _transactionRepository = MockRepositories.GetTransactionRepository();
        }

        [Fact]
        public async void ShouldCreateATransaction()
        {
            var handler = new CreateTransactionCommandHandler(_transactionRepository);
            var id = Guid.NewGuid();
            var request = new CreateTransactionCommand(id, DateTime.Now, Guid.NewGuid(), null, null, 10.00m, TransactionType.Debit,
                new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "Online"));

            Guid response = await handler.Handle(request, new System.Threading.CancellationToken());

            response.Should().Be(id);
            var trns = await _transactionRepository.GetAll();
            trns.Count().Should().Be(3);
        }
    }
}
