using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Preset.Commands.DeleteTenantSettings;

public record DeleteTenantSettingsCommand(long Id) : IRequest<Result>;
public class DeleteTenantSettingsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteTenantSettingsCommand, Result>
{
    public async Task<Result> Handle(DeleteTenantSettingsCommand request, CancellationToken ct)
    {
        var entity = await context.TenantSettings.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("TenantSettings not found.");

        context.TenantSettings.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

