using Accounting.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Accounting.Domain.Tests.Entities
{
    public class TagTest
    {
        public static IEnumerable<object[]> ValidTags =>
            new List<object[]>
            {
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Grocery" },
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "Food" }
            };

        public static IEnumerable<object[]> InvalidTagNames =>
            new List<object[]>
            {
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "" },
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, null },
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "   " },
            };


        [Theory]
        [MemberData(nameof(ValidTags))]
        public void CreateTagSuccessfully(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, string name)
        {
            var Tag = new Tag(id, createdOn, createdBy, modifiedOn, modifiedBy, name);

            Tag.ID.Should().Be(id);
            Tag.CreatedOn.Should().Be(createdOn);
            Tag.CreatedBy.Should().Be(createdBy);
            Tag.ModifiedOn.Should().Be(modifiedOn);
            Tag.ModifiedBy.Should().Be(modifiedBy);
            Tag.Name.Should().Be(name);
        }

        [Theory]
        [MemberData(nameof(InvalidTagNames))]
        public void ThrowExceptionWhenNameIsNotValid(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, string name)
        {
            Action action = () => new Tag(id, createdOn, createdBy, modifiedOn, modifiedBy, name);

            action.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter 'The {nameof(Tag.Name)} is invalid!')");
        }
    }
}
