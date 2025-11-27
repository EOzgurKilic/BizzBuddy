using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.RoleAssignment.Commands.UpdateRole;


public record UpdateRoleCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    public string? Description { get; set; }
}

public class UpdateRoleCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateRoleCommand, Result>
{
    public async Task<Result> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Role.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("Role not found");
        
        entity.RoleName = request.RoleName;
        entity.Description = request.Description;
        
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}