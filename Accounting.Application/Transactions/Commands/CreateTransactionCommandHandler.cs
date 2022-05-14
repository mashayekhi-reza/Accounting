using Accounting.Application.DTOs;
using Accounting.Domain.Entities;
using Accounting.Domain.Entities.Transaction;
using AutoMapper;
using MediatR;

namespace Accounting.Application.Transactions.Commands;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(
        ITransactionRepository transactionRepository,
        IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        this._mapper = mapper;
    }
    public Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Transaction(request.ID,
                                            request.CreatedOn,
                                            request.CreatedBy,
                                            request.ModifiedOn,
                                            request.ModifiedBy,
                                            request.Amount,
                                            request.Type,
                                            _mapper.Map<Account>(request.Account));

        return _transactionRepository.Insert(transaction);
    }
}
