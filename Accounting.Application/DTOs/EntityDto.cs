namespace Accounting.Application.DTOs;

public record EntityDto(Guid ID, DateTime CreatedOn, Guid CreatedBy, DateTime? ModifiedOn, Guid? ModifiedBy);