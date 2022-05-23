namespace Accounting.Application.DTOs;

public record TenantDto(Guid ID, DateTime CreatedOn, Guid CreatedBy, DateTime? ModifiedOn, Guid? ModifiedBy) 
    : EntityDto(ID, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy);