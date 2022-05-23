using Accounting.Common;
using Accounting.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Accounting.Domain.Tests.Entities;

public class AccountTest
{
    public static IEnumerable<object[]> ValidAccounts =>
        new List<object[]>
        {
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "Cash", 
                new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())},
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "My Bank",
                new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())}
        };

    public static IEnumerable<object[]> InvalidAccountNames =>
        new List<object[]>
        {
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), "" , 
                    new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid()) },
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, null, 
                    new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid()) },
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null, "   ",
                new Tenant(Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid())},
        };


    [Theory]
    [MemberData(nameof(ValidAccounts))]
    public void CreateAccountSuccessfully(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, string name, Tenant tenant)
    {
        var account = new Account(id, createdOn, createdBy, modifiedOn, modifiedBy, name, tenant);

        account.ID.Should().Be(id);
        account.CreatedOn.Should().Be(createdOn);
        account.CreatedBy.Should().Be(createdBy);
        account.ModifiedOn.Should().Be(modifiedOn);
        account.ModifiedBy.Should().Be(modifiedBy);
        account.Name.Should().Be(name);
        account.Tenant.Should().Be(tenant);
    }

    [Theory]
    [MemberData(nameof(InvalidAccountNames))]
    public void ThrowExceptionWhenAccountNameIsNotValid(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, string name, Tenant tenant)
    {
        Action action = () => new Account(id, createdOn, createdBy, modifiedOn, modifiedBy, name, tenant);

        action.Should().Throw<ValidationException>()
            .Where(e => e.ErrorCode == ErrorCode.InvalidAccountOperation)
            .WithMessage($"The {nameof(Account.Name)} is invalid!");

    }
}
