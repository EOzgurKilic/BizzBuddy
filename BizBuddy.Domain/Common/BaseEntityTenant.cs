using System;

namespace BizBuddy.Domain.Common;

public abstract class BaseEntityTenant:BaseEntity
{
    public int TenantId { get; set; }

}
