using Accounting.Domain.Entities;
using Accounting.Domain.Enums;
using MediatR;

namespace Accounting.Application.Transactions.Commands;

public class CreateTransactionCommand : IRequest<Guid>
{
    public Guid ID { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public Guid CreatedBy { get; private set; }
    public DateTime? ModifiedOn { get; private set; }
    public Guid? ModifiedBy { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public Account Account { get; private set; }
    public List<Tag> Tags { get; private set; }
}
