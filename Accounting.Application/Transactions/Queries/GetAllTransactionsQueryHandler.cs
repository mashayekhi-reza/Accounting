using Accounting.Application.DTOs;
using Accounting.Domain.Entities.Transaction;
using AutoMapper;
using MediatR;

namespace Accounting.Application.Transactions.Queries;

public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }
    public async Task<List<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository.GetAll();
        var transactionsDtos = _mapper.Map<List<TransactionDto>>(transactions);
        return transactionsDtos;
    }
}