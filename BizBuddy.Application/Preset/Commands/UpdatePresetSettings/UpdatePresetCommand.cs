using System;
using System.Text.Json;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Preset.Commands.UpdatePreset;


public record UpdatePresetCommand : IRequest<Result>
{
    public int Id { get; set; }
    public List<string> EnabledModules { get; set; }
    public List<string> MenuOrder { get; set; }
    public string? Notes { get; set; }
    public string? EnabledModulesJson { get; set; }
    public string? MenuOrderJson { get; set; }
    public string? DefaultFieldsJson { get; set; }
}

public class UpdatePresetCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdatePresetCommand, Result>
{
    public async Task<Result> Handle(UpdatePresetCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.PresetSettings.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("PresetSettings not found");

        entity.Notes = request.Notes;
        entity.EnabledModules = request.EnabledModules;
        entity.EnabledModulesJson =
                request.EnabledModulesJson
                ?? JsonSerializer.Serialize(request.EnabledModules ?? new List<string>());

        entity.MenuOrderJson =
            request.MenuOrderJson
            ?? JsonSerializer.Serialize(request.MenuOrder ?? new List<string>());
        entity.EnabledModulesJson = request.EnabledModulesJson;
        entity.MenuOrder = request.MenuOrder;
        entity.DefaultFieldsJson = request.DefaultFieldsJson;


        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}