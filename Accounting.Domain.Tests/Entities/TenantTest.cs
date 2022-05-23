using Accounting.Common;
using Accounting.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tenanting.Domain.Tests.Entities;

public class TenantTest
{
    public static IEnumerable<object[]> ValidTenants =>
        new List<object[]>
        {
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), DateTime.Now, Guid.NewGuid()},
            new object[] { Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), null, null}
        };


    [Theory]
    [MemberData(nameof(ValidTenants))]
    public void CreateTenantSuccessfully(Guid id, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy)
    {
        var Tenant = new Tenant(id, createdOn, createdBy, modifiedOn, modifiedBy);

        Tenant.ID.Should().Be(id);
        Tenant.CreatedOn.Should().Be(createdOn);
        Tenant.CreatedBy.Should().Be(createdBy);
        Tenant.ModifiedOn.Should().Be(modifiedOn);
        Tenant.ModifiedBy.Should().Be(modifiedBy);
    }
}
