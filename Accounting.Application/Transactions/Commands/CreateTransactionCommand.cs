using Accounting.Application.DTOs;
using Accounting.Domain.Enums;
using MediatR;

namespace Accounting.Application.Transactions.Commands;

public class CreateTransactionCommand : EntityDto, IRequest<Guid>
{
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public AccountDto Account { get; private set; }

    public CreateTransactionCommand(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy, 
        decimal amount, TransactionType type, AccountDto account) : base(id, createdOn, createdBy, modifiedOn, modifiedBy)
    {
        Amount = amount;
        Type = type;
        Account = account;
    }
}
