using System;
using System.Threading.Tasks;

namespace Accounting.Domain.Entities.Transaction;

public interface ITransactionRepository
{
    Task<Guid> Insert(Transaction transaction);
}

