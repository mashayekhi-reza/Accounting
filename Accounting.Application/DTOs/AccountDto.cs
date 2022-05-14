namespace Accounting.Application.DTOs
{
    public class AccountDto : EntityDto
    {
        public string Name { get; private set; }

        public AccountDto(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy, string name)
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy)
        {
            Name = name;
        }
    }
}