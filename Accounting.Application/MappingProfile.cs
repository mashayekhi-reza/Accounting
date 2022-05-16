using Accounting.Application.DTOs;
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
    }
}


