using Accounting.Domain.Entities.Transaction;
using MediatR;

namespace Accounting.Application.Transactions.Commands;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
{
    private readonly ITransactionRepository _transactionRepository;

    public CreateTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
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
                                            request.Account);

        return _transactionRepository.Insert(transaction);
    }
}
