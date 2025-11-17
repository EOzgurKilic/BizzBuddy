using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Staff;
using MediatR;

namespace BizBuddy.Application.Staff.Commands;


public record CreateEmployeeCommand : IRequest<Result<long>>
{


    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Password { get; set; }
}
public class CreateEmployeeCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateEmployeeCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {

        var entity = new Employee
        {
            Name = request.Name,
            SurName = request.SurName,
            Email = request.Email,
            Phone = request.Phone,
            Password = request.Password,
        };

        context.Employee.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }
}
