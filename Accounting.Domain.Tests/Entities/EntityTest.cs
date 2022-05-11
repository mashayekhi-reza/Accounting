using Accounting.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Accounting.Domain.Tests.Entities
{
    public class EntityTest
    {
        public static IEnumerable<object[]> ValidEntities =>
            new List<object[]>
            {
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null },
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid() },
                new object[] {
                    new Guid("9086DC70-DC42-470C-912D-6E68FC8E885B"), new DateTime(2022, 5, 10, 10, 10, 10),
                    new Guid("48FB0717-EA9D-4371-B4B6-C796C7E97BF3"), new DateTime(2022, 5, 10, 10, 10, 11),
                    new Guid("3B0622CC-7B11-4C19-91EE-EC34F74D6088") }
            };

        public static IEnumerable<object[]> InvalidModifiedOn =>
            new List<object[]>
            {
                new object[] { Guid.NewGuid(), new DateTime(2022, 5, 10), Guid.NewGuid(), new DateTime(2022, 5, 9), Guid.NewGuid() },
                new object[] { Guid.NewGuid(), new DateTime(2022, 5, 10), Guid.NewGuid(), new DateTime(2022, 5, 10), Guid.NewGuid() }
            };

        [Theory]
        [MemberData(nameof(ValidEntities))]
        public void CreateEntitySuccessfully(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy)
        {
            var entity = new MockEntity(id, createdOn, createdBy, modifiedOn, modifiedBy);

            entity.GetType().BaseType.Should().Be(typeof(Entity));
            entity.ID.Should().Be(id);
            entity.CreatedOn.Should().Be(createdOn);
            entity.CreatedBy.Should().Be(createdBy);
            entity.ModifiedOn.Should().Be(modifiedOn);
            entity.ModifiedBy.Should().Be(modifiedBy);
        }

        [Theory]
        [MemberData(nameof(InvalidModifiedOn))]
        public void ThrowExceptionWhenModifiedOnIsNotLaterThanCreatedOn(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy)
        {
            Action action = () => new MockEntity(id, createdOn, createdBy, modifiedOn, modifiedBy);

            action.Should().Throw<ArgumentException>().WithMessage($"The {nameof(Entity.ModifiedOn)} should be later than {nameof(Entity.CreatedOn)}!");
        }
    }

    public class MockEntity : Entity
    {
        public MockEntity(Guid id, DateTime createdOn, Guid createdBy, DateTime? modifiedOn, Guid? modifiedBy)
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy)
        {
        }
    }
}
