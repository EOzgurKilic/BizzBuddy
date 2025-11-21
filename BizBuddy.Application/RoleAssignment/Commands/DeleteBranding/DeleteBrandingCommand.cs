using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.RoleAssignment.Commands.DeleteBranding;

public record DeleteBrandingCommand(long Id) : IRequest<Result>;
public class DeleteBrandingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteBrandingCommand, Result>
{
    public async Task<Result> Handle(DeleteBrandingCommand request, CancellationToken ct)
    {
        var entity = await context.Branding.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Branding not found.");

        context.Branding.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

