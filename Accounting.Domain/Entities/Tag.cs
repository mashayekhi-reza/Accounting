using System;

namespace Accounting.Domain.Entities
{
    public class Tag : Entity
    {
        public Tag(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy, string name) 
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException($"The {nameof(Name)} is invalid!");

            Name = name;
        }

        public string Name { get; private set; }
    }
}