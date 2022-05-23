using System;

namespace Accounting.Domain.Entities;

public class Tenant : Entity
{
    public Tenant(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy) 
        : base(id, createdOn, createdBy, modifiedOn, modifiedBy)
    {
    }
}