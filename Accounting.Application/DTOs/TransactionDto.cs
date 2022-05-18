using Accounting.Domain.Enums;

namespace Accounting.Application.DTOs;

public record TransactionDto(Guid ID,
                             DateTime CreatedOn,
                             Guid CreatedBy,
                             DateTime? ModifiedOn,
                             Guid? ModifiedBy,
                             decimal Amount,
                             TransactionType Type,
                             AccountDto Account)
    : EntityDto(ID, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy);