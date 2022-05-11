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
            if (modifiedOn != DateTime.MinValue & modifiedOn <= createdOn)
                throw new ArgumentException($"The {nameof(ModifiedOn)} should be later than {nameof(CreatedOn)}!");

            ID = id;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
        }
    }
}