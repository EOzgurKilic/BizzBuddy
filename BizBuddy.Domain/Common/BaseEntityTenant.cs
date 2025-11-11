using System;

namespace BizBuddy.Domain.Common;

public abstract class BaseEntityTenant:BaseEntity
{
    public long TenantId { get; set; }

}
