using System;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Staff;

namespace BizBuddy.Application.Staff.Queries.GetEmployeeDetail;

public class EmployeeDto : IMapFrom<Employee>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Password { get; set; }
}
