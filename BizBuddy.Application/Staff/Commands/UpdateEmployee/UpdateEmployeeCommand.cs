using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Staff.Commands.UpdateEmployee;

public record UpdateEmployeeCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Password { get; set; }
}

public class UpdateEmployeeCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateEmployeeCommand, Result>
{
    public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Employee.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("Employee not found");

        entity.Name = request.Name;
        entity.SurName = request.SurName;
        entity.Email = request.Email;
        entity.Phone = request.Phone;
        entity.Password = request.Password;


        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}