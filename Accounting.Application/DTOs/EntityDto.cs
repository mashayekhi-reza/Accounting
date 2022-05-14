namespace Accounting.Application.DTOs
{
    public class EntityDto
    {
        public EntityDto(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy)
        {
            ID = id;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
        }

        public Guid ID { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public Guid CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public Guid? ModifiedBy { get; private set; }
    }
}