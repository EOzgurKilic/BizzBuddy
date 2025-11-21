using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Tenat.Commands.DeleteTenant;

public record DeleteTenantCommand(long Id) : IRequest<Result>;
public class DeleteTenantCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteTenantCommand, Result>
{
    public async Task<Result> Handle(DeleteTenantCommand request, CancellationToken ct)
    {
        var entity = await context.Tenat.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Tenant not found.");

        context.Tenat.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

