using System;

namespace Accounting.Domain.Entities
{
    public class Account : Entity
    {
        public Account(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy, string name) 
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy)
        {
            Name = name;
        }

        //TODO: tests
        public string Name { get; private set; }
    }
}