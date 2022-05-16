using Accounting.Application.DTOs;
using Accounting.Application.Tests.Mocks;
using Accounting.Application.Transactions.Commands;
using Accounting.Domain.Entities;
using Accounting.Domain.Entities.Transaction;
using Accounting.Domain.Enums;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandlerTest()
        {
            _transactionRepository = MockRepositories.GetTransactionRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<AccountDto, Account>(); 
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async void ShouldCreateATransaction()
        {
            var handler = new CreateTransactionCommandHandler(_transactionRepository, _mapper);
            var id = Guid.NewGuid();
            var request = new CreateTransactionCommand(new TransactionDto(id, DateTime.Now, Guid.NewGuid(), null, null, 10.00m, TransactionType.Debit,
                new AccountDto(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "Online")));

            Guid response = await handler.Handle(request, new System.Threading.CancellationToken());

            response.Should().Be(id);
            var trns = await _transactionRepository.GetAll();
            trns.Count().Should().Be(3);
        }
    }
}
