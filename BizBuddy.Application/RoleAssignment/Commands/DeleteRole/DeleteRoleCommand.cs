using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.RoleAssignment.Commands.DeleteRole;


public record DeleteRoleCommand(long Id) : IRequest<Result>;
public class DeleteRoleCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteRoleCommand, Result>
{
    public async Task<Result> Handle(DeleteRoleCommand request, CancellationToken ct)
    {
        var entity = await context.Role.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Role not found.");

        context.Role.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}