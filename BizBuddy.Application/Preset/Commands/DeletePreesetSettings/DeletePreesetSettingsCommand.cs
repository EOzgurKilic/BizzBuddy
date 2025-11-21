using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Preset.Commands.DeletePreesetSettings;

public record DeletePreesetSettingsCommand(long Id) : IRequest<Result>;
public class DeletePreesetSettingsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeletePreesetSettingsCommand, Result>
{
    public async Task<Result> Handle(DeletePreesetSettingsCommand request, CancellationToken ct)
    {
        var entity = await context.PresetSettings.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("PresetSettings not found.");

        context.PresetSettings.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

