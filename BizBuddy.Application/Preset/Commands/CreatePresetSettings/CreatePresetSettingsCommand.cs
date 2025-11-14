using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Preset;
using MediatR;

namespace BizBuddy.Application.Preset.Commands;



public record CreatePresetSettingsCommand : IRequest<Result<long>>
{
      public int Id { get; set; }
    public List<string> EnabledModules { get; set; }
    public List<string> MenuOrder { get; set; }
    public string? Notes { get; set; }
    public string? EnabledModulesJson { get; set; }   
    public string? MenuOrderJson { get; set; }       
    public string? DefaultFieldsJson { get; set; }

}
public class CreatePresetSettingsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreatePresetSettingsCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreatePresetSettingsCommand request, CancellationToken cancellationToken)
    {

        var entity = new PresetSettings
        {
            Id = request.Id,
            EnabledModules = request.EnabledModules,
            MenuOrder = request.MenuOrder,
            Notes = request.Notes,
            EnabledModulesJson = request.EnabledModulesJson,
            MenuOrderJson = request.MenuOrderJson,
            DefaultFieldsJson = request.DefaultFieldsJson
        };

        context.PresetSettings.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }
}
