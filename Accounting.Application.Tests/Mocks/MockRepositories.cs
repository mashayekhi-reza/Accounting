using Accounting.Domain.Entities;
using Accounting.Domain.Entities.Transaction;
using Accounting.Domain.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounting.Application.Tests.Mocks;

public static class MockRepositories
{

    public static ITransactionRepository GetTransactionRepository()
    {
        var transactions = new List<Transaction>
        {
            new Transaction(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, 10.00m, TransactionType.Credit,
            new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "Cash")),

            new Transaction(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, 10.00m, TransactionType.Credit,
            new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "Bank"))
        };

        var repo = new Mock<ITransactionRepository>();

        repo.Setup(r => r.Insert(It.IsAny<Transaction>())).ReturnsAsync((Transaction transaction) =>
        {
            transactions.Add(transaction);

            return transactions.Last();
        });

        repo.Setup(r => r.GetAll()).ReturnsAsync(transactions);

        return repo.Object;
    }
}
