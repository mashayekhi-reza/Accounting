using Accounting.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Accounting.Domain.Tests.Entities
{
    public class AccountTest
    {
        public static IEnumerable<object[]> ValidAccounts =>
            new List<object[]>
            {
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Cash" },
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "My Bank" }
            };

        public static IEnumerable<object[]> InvalidAccountNames =>
            new List<object[]>
            {
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "" },
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, null },
                new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "   " },
            };


        [Theory]
        [MemberData(nameof(ValidAccounts))]
        public void CreateAccountSuccessfully(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, string name)
        {
            var account = new Account(id, createdOn, createdBy, modifiedOn, modifiedBy, name);

            account.ID.Should().Be(id);
            account.CreatedOn.Should().Be(createdOn);
            account.CreatedBy.Should().Be(createdBy);
            account.ModifiedOn.Should().Be(modifiedOn);
            account.ModifiedBy.Should().Be(modifiedBy);
            account.Name.Should().Be(name);
        }

        [Theory]
        [MemberData(nameof(InvalidAccountNames))]
        public void ThrowExceptionWhenNameIsNotValid(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, string name)
        {
            Action action = () => new Account(id, createdOn, createdBy, modifiedOn, modifiedBy, name);

            action.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter 'The {nameof(Account.Name)} is invalid!')");
        }
    }
}
