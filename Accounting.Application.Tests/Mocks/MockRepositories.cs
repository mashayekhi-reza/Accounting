using Accounting.Domain.Entities;
using Accounting.Domain.Entities.Transaction;
using Accounting.Domain.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return transactions.Last().ID;
        });

        repo.Setup(r => r.GetAll()).ReturnsAsync(transactions);

        return repo.Object;
    }


    //private List<Transaction> _transactions;

    //public MockRepositories()
    //{
    //    _transactions = new List<Transaction>
    //    {
    //        new Transaction(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, 10.00m, TransactionType.Credit,
    //        new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "Cash")),

    //        new Transaction(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, 10.00m, TransactionType.Credit,
    //        new Account(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "Bank"))
    //    };

    //    var mockRepo = new Mock<ILeaveTypeRepository>();

    //    mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

    //    mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
    //    {
    //        leaveTypes.Add(leaveType);
    //        return leaveType;
    //    });

    //    return mockRepo;
    //}

    //public Task<Guid> Insert(Transaction transaction)
    //{
    //    _transactions.Add(transaction);
    //    return Task.FromResult(_transactions.Last().ID);
    //}
}
