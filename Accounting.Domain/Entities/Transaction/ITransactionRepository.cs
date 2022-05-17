using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accounting.Domain.Entities.Transaction;

public interface ITransactionRepository
{
    Task<Transaction> Insert(Transaction transaction);
}

