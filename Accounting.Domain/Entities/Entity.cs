using System;

namespace Accounting.Domain.Entities
{
    public abstract class Entity
    {
        public Guid ID { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public Guid CreatedBy { get; protected set; }
        public DateTime? ModifiedOn { get; protected set; }
        public Guid? ModifiedBy { get; protected set; }

        public Entity(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy)
        {
            // TODO: add test and validation
            ID = id;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
        }
    }
}