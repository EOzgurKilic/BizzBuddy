using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Staff.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(long Id) : IRequest<Result>;
public class DeleteEmployeeCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteEmployeeCommand, Result>
{
    public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken ct)
    {
        var entity = await context.Employee.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Employee not found.");

        context.Employee.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

