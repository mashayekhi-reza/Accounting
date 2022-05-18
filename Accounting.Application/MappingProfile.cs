using Accounting.Application.DTOs;
using Accounting.Application.Transactions.Commands;
using Accounting.Domain.Entities;
using Accounting.Domain.Entities.Transaction;
using AutoMapper;

namespace Accounting.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AccountDto, Account>().ReverseMap();
        CreateMap<Transaction, TransactionDto>();
        CreateMap<CreateTransactionCommand, Transaction>()
            .ConvertUsing((src, _, context) => new Transaction(src.Transaction.ID,
                                            src.Transaction.CreatedOn,
                                            src.Transaction.CreatedBy,
                                            src.Transaction.ModifiedOn,
                                            src.Transaction.ModifiedBy,
                                            src.Transaction.Amount,
                                            src.Transaction.Type,
                                            context.Mapper.Map<Account>(src.Transaction.Account)));
    }
}


