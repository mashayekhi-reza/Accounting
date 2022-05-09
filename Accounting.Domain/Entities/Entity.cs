using System;

namespace Accounting.Domain.Entities
{
    public class Entity
    {
        public Guid ID { get; } = Guid.NewGuid();
    }
}