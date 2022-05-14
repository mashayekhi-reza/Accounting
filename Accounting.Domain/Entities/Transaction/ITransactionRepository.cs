using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accounting.Domain.Entities.Transaction;

public interface ITransactionRepository
{
    Task<Guid> Insert(Transaction transaction);
    Task<List<Transaction>> GetAll();
}

