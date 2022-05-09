using System;

namespace Accounting.Domain.Entities
{
    public class Tag : Entity
    {
        public Tag(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy, string name) 
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy)
        {
            Name = name;
        }

        // TODO: test
        public string Name { get; private set; }
    }
}