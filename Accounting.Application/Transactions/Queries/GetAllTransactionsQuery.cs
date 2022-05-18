using Accounting.Application.DTOs;
using MediatR;

namespace Accounting.Application.Transactions.Queries;

public record GetAllTransactionsQuery() : IRequest<List<TransactionDto>>;
