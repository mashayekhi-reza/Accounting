using Accounting.Application.DTOs;
using MediatR;

namespace Accounting.Application.Transactions.Commands;

public record CreateTransactionCommand(TransactionDto Transaction) : IRequest<Guid>;