using Accounting.Application.DTOs;
using Accounting.Domain.Entities.Transaction;
using AutoMapper;
using MediatR;

namespace Accounting.Application.Transactions.Commands;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionDto>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(
        ITransactionRepository transactionRepository,
        IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }
    public async Task<TransactionDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var requestedTransaction = _mapper.Map<Transaction>(request);

        var savedTransaction = await _transactionRepository.Insert(requestedTransaction);
        var transactionDto = _mapper.Map<TransactionDto>(savedTransaction);
        return transactionDto;
    }
}
