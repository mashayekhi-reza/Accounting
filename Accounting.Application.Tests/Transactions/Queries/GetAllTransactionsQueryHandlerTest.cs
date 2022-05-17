using Accounting.Application.Tests.Mocks;
using Accounting.Application.Transactions.Queries;
using Accounting.Domain.Entities.Transaction;
using AutoMapper;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace Accounting.Application.Tests.Transactions.Queries;

public class GetAllTransactionsQueryHandlerTest
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetAllTransactionsQueryHandlerTest()
    {
        _transactionRepository = MockRepositories.GetTransactionRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async void GetAllTransctions()
    {
        var handler = new GetAllTransactionsQueryHandler(_transactionRepository, _mapper);        
        
        var transactions = await handler.Handle(new GetAllTransactionsQuery(), new System.Threading.CancellationToken());

        transactions.Count().Should().Be(2);
    }
}
