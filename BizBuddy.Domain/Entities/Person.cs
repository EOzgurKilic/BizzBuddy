using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities;

public class Person : BaseEntity
{

    public long Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
