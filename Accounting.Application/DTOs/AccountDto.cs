namespace Accounting.Application.DTOs;

public record AccountDto(Guid ID, DateTime CreatedOn, Guid CreatedBy, DateTime? ModifiedOn, Guid? ModifiedBy, string Name) 
    : EntityDto(ID, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy);