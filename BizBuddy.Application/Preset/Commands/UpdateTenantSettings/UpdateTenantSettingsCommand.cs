using System;
using System.Text.Json;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Preset.Commands.UpdateTenantSettings;

public record UpdateTenantSettingsCommand : IRequest<Result>
{

    public int Id { get; set; }
    public List<string> EnabledModules { get; set; }
    public List<string> MenuOrder { get; set; }
    public int BrandingId { get; set; }
}

public class UpdateTenantSettingsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateTenantSettingsCommand, Result>
{
    public async Task<Result> Handle(UpdateTenantSettingsCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TenantSettings.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("TenantSettings not found");
     
        entity.EnabledModules = request.EnabledModules;
        entity.MenuOrder = request.MenuOrder;
        entity.BrandingId = request.BrandingId;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}